using DefaultNamespace;
using DefaultNamespace.Cell;
using DefaultNamespace.Grid;
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
          GridInstaller
              .Install(Container);
          CellInstaller
              .Install(Container);
          
          Container.Bind<GameController>().AsSingle().NonLazy();
        }
    }
}