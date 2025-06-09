using Camera;
using Zenject;

namespace MainCamera
{
    public class CameraInstaller : Installer<CameraInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<CameraController>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<CameraView>()
                .FromComponentInNewPrefabResource("Camera")
                .AsSingle()
                .NonLazy();
        }
    }
}