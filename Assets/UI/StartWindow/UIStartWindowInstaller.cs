using Zenject;

namespace UI.StartWindow
{
    public class UIStartWindowInstaller : Installer<UIStartWindowInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<UIStartWindowController>()
                .AsSingle()
                .NonLazy();
        }
    }
}