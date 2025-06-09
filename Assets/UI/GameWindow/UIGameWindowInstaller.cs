using Zenject;

namespace UI.GameWindow
{
    public class UIGameWindowInstaller : Installer<UIGameWindowInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<UIGameWindowController>()
                .AsSingle()
                .NonLazy();
        }
    }
}