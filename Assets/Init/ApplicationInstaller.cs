using DefaultNamespace;
using MainCamera;
using Zenject;

namespace Init
{
    public class ApplicationInstaller : MonoInstaller<ApplicationInstaller>
    {
        public override void InstallBindings()
        {
            CameraInstaller
                .Install(Container);
            
          UIRootInstaller
              .Install(Container);
          Container.Bind<GameController>().AsSingle().NonLazy();
        }
    }
}