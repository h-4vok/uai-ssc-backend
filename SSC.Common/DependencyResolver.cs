using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Registration;
using Unity.Resolution;

namespace SSC.Common
{
    public class DependencyResolver
    {
        private DependencyResolver()
        {
            this.container = new UnityContainer();
        }
        static DependencyResolver() { }
        
        public static DependencyResolver Obj { get; } = new DependencyResolver();

        private IUnityContainer container;

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
