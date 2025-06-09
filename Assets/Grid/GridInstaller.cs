using Zenject;

namespace DefaultNamespace.Grid
{
    public class GridInstaller : Installer<GridInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<GridController>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindMemoryPool<GridView, GridView.Pool>()
                .FromComponentInNewPrefabResource("Grid");
        }
    }
}