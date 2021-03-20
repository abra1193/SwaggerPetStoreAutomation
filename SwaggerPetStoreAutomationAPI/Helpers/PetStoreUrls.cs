namespace SwaggerPetStoreAutomationAPI.Helpers
{
    internal static class PetStoreUrls
    {
        #region Orders
        internal const string PlaceAnOrderForAPet = @"store/order";
        internal const string PetInventoryByStatus = @"store/inventory";
        internal const string DeletePurchaseOrderById = @"store/order/{orderId}";
        #endregion

        #region Users
        internal const string CreateUser = @"user";
        internal const string LogInUser = @"user/login";
        internal const string LogOutUser = @"user/logout";
        internal const string GetUserByUsername = @"user/{username}";
        #endregion

        #region Pets
        internal const string AddNewPetToStore = @"pet";
        internal const string FindPetById = @"pet/{petId}";
        internal const string FindPetByStatus = @"pet/findByStatus";
        internal const string FindPetByTags = @"pet/findByTags";
        internal const string UploadAnImageToAPet = @"pet/{petId}/uploadImage";
        #endregion
    }
}