using System;
using System.IO;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Serilog;
using Serilog.Context;
using Serilog.Events;
using Serilog.Formatting.Display;
using Xunit.Abstractions;

namespace SwaggerPetStoreAutomationAPI.Helpers
{
    public class LoggingHelper
    {
        private static readonly Subject<LogEvent> SLogEventSubject = new Subject<LogEvent>();
        private const string CaptureCorrelationIdKey = "CaptureCorrelationId";

        private static readonly MessageTemplateTextFormatter s_formatter = new MessageTemplateTextFormatter(
            "{Message}", null);

        public LoggingHelper()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo
                .Observers(observable => observable.Subscribe(logEvent => SLogEventSubject.OnNext(logEvent)))
                .Enrich.FromLogContext()
                .CreateLogger();
        }

        public IDisposable Capture(ITestOutputHelper testOutputHelper)
        {
            var captureId = Guid.NewGuid();

            var subscription = SLogEventSubject.Where(Filter).Subscribe(logEvent =>
            {
                using var writer = new StringWriter();
                s_formatter.Format(logEvent, writer);
                testOutputHelper.WriteLine(writer.ToString());
                writer.Close();
            });
            var pushProperty = LogContext.PushProperty(CaptureCorrelationIdKey, captureId);

            return new DisposableAction(() =>
            {
                subscription.Dispose();
                pushProperty.Dispose();
            });

            bool Filter(LogEvent logEvent) =>
                logEvent.Properties.ContainsKey(CaptureCorrelationIdKey) &&
                logEvent.Properties[CaptureCorrelationIdKey].ToString() == captureId.ToString();
        }

        private class DisposableAction : IDisposable
        {
            private readonly Action _action;

            public DisposableAction(Action action)
            {
                _action = action;
            }

            public void Dispose()
            {
                _action();
            }
        }
    }
}