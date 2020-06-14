namespace OrenHakaton.App_Start
{
    using Unity;
    using Unity.Lifetime;

    using OrenHakaton.Controllers;
    using OrenHakaton.Models;

    public static class UnityConfig
    {
        public static IUnityContainer _unityContainer { get; }

        static UnityConfig()
        {
            _unityContainer = new UnityContainer();

            _unityContainer.RegisterType(typeof(IEntityService), typeof(AuthorizationService), "authorization", new HierarchicalLifetimeManager());
            _unityContainer.RegisterType(typeof(IEntityService), typeof(RequestsService), "requests", new HierarchicalLifetimeManager());
            _unityContainer.RegisterType(typeof(IEntityService), typeof(HousesService), "houses", new HierarchicalLifetimeManager());
            _unityContainer.RegisterType(typeof(IEntityService), typeof(EmployesService), "employes", new HierarchicalLifetimeManager());
            _unityContainer.RegisterType(typeof(IEntityService), typeof(MeetingService), "meetings", new HierarchicalLifetimeManager());
            _unityContainer.RegisterType(typeof(IEntityService), typeof(ManagementCompaniesService), "managecomp", new HierarchicalLifetimeManager());
        }
    }
}
