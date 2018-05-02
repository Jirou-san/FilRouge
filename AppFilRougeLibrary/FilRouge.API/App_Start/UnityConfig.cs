using System;
using FilRouge.Model.Entities;
using Unity;
using IReferenceService = FilRouge.Model.Interfaces.IReferenceService;
namespace FilRouge.API
{
    using FilRouge.Model.Interfaces;
    using FilRouge.Service;

    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container

        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(
            () =>
                {
                    var container = new UnityContainer();
                    RegisterTypes(container);
                    return container;
                });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;

        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            //container.RegisterType<ReferencesService>(new HierarchicalLifetimeManager());
            container.RegisterType<IQuizzService, QuizzService>();
            container.RegisterType<IReferenceService, ReferencesService>();
            container.RegisterType<IQuestionResponseService, QuestionResponseService>();
            container.RegisterType<IQuestionQuizzService, QuestionQuizzService>();
        }    
    }
}