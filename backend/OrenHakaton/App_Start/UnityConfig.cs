namespace OrenHakaton.App_Start
{
    using Unity;
    using Unity.Lifetime;

    using OrenHakaton.Controllers;

    public static class UnityConfig
    {
        public static IUnityContainer _unityContainer { get; }

        static UnityConfig()
        {
            _unityContainer = new UnityContainer();
            _unityContainer.RegisterType(typeof(IEntityService), typeof(AuthorizationService), "Authorization", new HierarchicalLifetimeManager());
            _unityContainer.RegisterType(typeof(IEntityService), typeof(RequestsService), "Requests", new HierarchicalLifetimeManager());
        }
    }
}
