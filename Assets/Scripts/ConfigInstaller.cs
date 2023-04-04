using Zenject;
using UnityEngine;

namespace DefaultNamespace
{
    
    public class ConfigInstaller : MonoInstaller
    {
        public bool UseRealConfigLoader = true;

        public override void InstallBindings()
        {
            if (UseRealConfigLoader)
            {
                Container.Bind<IConfigLoader>().To<ConfigLoader>().AsSingle().NonLazy();
            }
            else
            {
                Container.Bind<IConfigLoader>().To<DummyConfigLoader>().AsSingle().NonLazy();
            }

        }
    }
}