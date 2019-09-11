using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using Unity;
using Unity.Registration;
using Unity.Resolution;

namespace SSC.Common
{
    public class DependencyResolver : IDependencyResolver
    {
        #region Singleton
        private DependencyResolver(IUnityContainer container = null)
        {
            this.container = container ?? new UnityContainer();
        }
        static DependencyResolver() { }
        
        public static DependencyResolver Obj { get; } = new DependencyResolver();

        private IUnityContainer container;

        #endregion

        #region IDependencyResolver

        public object GetService(Type serviceType)
        {
            return this.container.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.container.ResolveAll(serviceType);
        }

        public IDependencyScope BeginScope()
        {
            var child = this.container.CreateChildContainer();
            return new DependencyResolver(child);
        }

        public void Dispose()
        {
            this.container.Dispose();
        }

        #endregion

        public void SetContainer(IUnityContainer container)
        {
            this.container = container;
        }

        public T Resolve<T>()
        {
            return this.container.Resolve<T>();
        }

        public T Resolve<T>(string key)
        {
            return this.container.Resolve<T>(key);
        }

        public T Resolve<T>(string key, params ResolverOverride[] overrides)
        {
            return this.container.Resolve<T>(key, overrides);
        }

        public void Register<Interface, Concrete>() where Concrete : Interface
        {
            this.container.RegisterType<Interface, Concrete>();
        }

        public void Register<Interface, Concrete>(string key) where Concrete : Interface
        {
            this.container.RegisterType<Interface, Concrete>(key);
        }

        public void Register<Interface>(InjectionMember injectionMember)
        {
            this.container.RegisterType<Interface>(injectionMember);
        }

        public void RegisterSingleton<Interface>(Interface instance)
        {
            this.container.RegisterInstance<Interface>(instance);
        }
    }
}
