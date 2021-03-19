using System;
using SwaggerPetStoreAutomationAPI;
using SwaggerPetStoreAutomationAPI.Actions;
using Xunit.Abstractions;

namespace SwaggerPetStoreAutomationTests.BaseTests
{
    public abstract class BaseClass : IDisposable
    {
        private readonly ITestOutputHelper _output;
        protected IDisposable logCapture;
        internal readonly ActionFactory Actions = new ActionFactory();
        internal readonly SharedStepFactory SharedSteps = new SharedStepFactory();

        protected BaseClass(ITestOutputHelper outputHelper)
        {
            _output = outputHelper;
            logCapture = new LoggingHelper().Capture(_output);
        }

        public void Dispose()
        {
            logCapture.Dispose();
        }
    }
}