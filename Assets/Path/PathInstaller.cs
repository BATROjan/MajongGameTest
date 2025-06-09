using Zenject;

namespace DefaultNamespace.Path
{
    public class PathInstaller :Installer<PathInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<PathController>()
                .AsSingle()
                .NonLazy();
        }
    }
}