using Zenject;

namespace DefaultNamespace.Cell
{
    public class CellInstaller : Installer<CellInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<CellConfig>()
                .FromScriptableObjectResource("CellConfig")
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<CellController>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindMemoryPool<CellView, CellView.Pool>()
                .FromComponentInNewPrefabResource("CellView");
        }
    }
}