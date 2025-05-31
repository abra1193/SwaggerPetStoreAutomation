using System;
using SwaggerPetStoreAutomationAPI;
using SwaggerPetStoreAutomationAPI.Actions;
using SwaggerPetStoreAutomationAPI.Helpers;
using Xunit.Abstractions;

namespace SwaggerPetStoreAutomationTests.BaseTests
{
    public abstract class BaseClass : IDisposable
    {
        private readonly IDisposable _logCapture;
        internal readonly ActionFactory Actions = new ActionFactory();
        internal readonly SharedStepFactory SharedSteps = new SharedStepFactory();

        protected BaseClass(ITestOutputHelper outputHelper)
        {
            _logCapture = new LoggingHelper().Capture(outputHelper);
        }

        public void Dispose()
        {
            _logCapture.Dispose();
        }
    }
}