using SwaggerPetStoreAutomationTests.SharedSteps;

namespace SwaggerPetStoreAutomationAPI.Actions
{
    public class SharedStepFactory
    {
        private OrderSharedSteps _orderSharedSteps;
        private UserSharedSteps _userSharedSteps;
        private PetsSharedSteps _petSharedSteps;

        public OrderSharedSteps OrderSharedSteps => _orderSharedSteps ??= new OrderSharedSteps();
        public UserSharedSteps UserSharedSteps => _userSharedSteps ??= new UserSharedSteps();
        public PetsSharedSteps PetsSharedSteps => _petSharedSteps ??= new PetsSharedSteps();
    }
}