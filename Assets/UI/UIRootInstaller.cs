using UI;
using UI.GameWindow;
using UI.StartWindow;
using Zenject;


    public class UIRootInstaller : Installer<UIRootInstaller>
    {
        public override void InstallBindings()
        {
            UIStartWindowInstaller.Install(Container);
            UIGameWindowInstaller.Install(Container);
            
            Container.Bind<IUIRoot>()
                .FromComponentInNewPrefabResource("Canvas")
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IUIService>()
                .To<UIService>()
                .AsSingle()
                .NonLazy();        }
    }
