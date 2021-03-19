namespace SwaggerPetStoreAutomationAPI.Actions
{
    public class ActionFactory
    {
        private OrderActions _orderActions;
        private UserActions _userActions;
        private PetsActions _petActions;

        public OrderActions OrderActions => _orderActions ??= new OrderActions();
        public UserActions UserActions => _userActions ??= new UserActions();
        public PetsActions PetsActions => _petActions ??= new PetsActions();
    }
}