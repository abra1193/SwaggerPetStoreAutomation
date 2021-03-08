using SwaggerPetStoreAutomationTests.Logging;
using System;
using Xunit.Abstractions;

namespace SwaggerPetStoreAutomationTests.BaseTests
{
    public class BaseClass : IDisposable
    {
        private readonly ILog Logger;
        protected readonly ITestOutputHelper output;
        protected readonly IDisposable _logCapture;

        public BaseClass(ITestOutputHelper outputHelper)
        {
            output = outputHelper;
            _logCapture = LoggingHelper.Capture(outputHelper);
            Logger = LogProvider.GetLogger(GetType().ToString());
        }

        public void Dispose()
        {
            _logCapture.Dispose();
        }
    }
}