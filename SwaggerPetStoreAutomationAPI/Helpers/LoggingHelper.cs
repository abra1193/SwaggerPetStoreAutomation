using Serilog;
using Serilog.Context;
using Serilog.Events;
using Serilog.Formatting.Display;
using System;
using System.IO;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Xunit.Abstractions;

namespace SwaggerPetStoreAutomationAPI
{
    public class LoggingHelper
    {
        private static readonly Subject<LogEvent> s_logEventSubject = new Subject<LogEvent>();
        private const string CaptureCorrelationIdKey = "CaptureCorrelationId";

        private static readonly MessageTemplateTextFormatter s_formatter = new MessageTemplateTextFormatter(
            "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}", null);

        public LoggingHelper()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo
                .Observers(observable => observable.Subscribe(logEvent => s_logEventSubject.OnNext(logEvent)))
                .Enrich.FromLogContext()
                .CreateLogger();
        }

        public IDisposable Capture(ITestOutputHelper testOutputHelper)
        {
            var captureId = Guid.NewGuid();

            bool filter(LogEvent logEvent) =>
                logEvent.Properties.ContainsKey(CaptureCorrelationIdKey) &&
                logEvent.Properties[CaptureCorrelationIdKey].ToString() == captureId.ToString();

            var subscription = s_logEventSubject.Where(filter).Subscribe(logEvent =>
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