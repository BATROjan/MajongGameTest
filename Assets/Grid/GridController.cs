using ModestTree;
using UI;
using UI.GameWindow;

namespace DefaultNamespace.Grid
{
    public class GridController
    {
        private readonly IUIService _uiService;
        private readonly GridView.Pool _gridPool;
        private GridView gridView;
        
        public GridController(
            IUIService uiService,
            GridView.Pool gridPool)
        {
            _uiService = uiService;
            _gridPool = gridPool;
        }

        public void SpawnGrid()
        {
            gridView = _gridPool.Spawn();
            gridView.gameObject.transform.SetParent(_uiService.Get<GameWindowView>().transform, false);
        }

        public GridLayer[] GetGridLayers()
        {
            return gridView.Layers;
        }

        public void DeletCellFromClosenList(GridCellView deletedCellView, GridCellView targetView)
        {
            var list = targetView.ClosenGridViews;
            foreach (var cell in list)
            {
                if (cell == deletedCellView)
                {
                    var targetlist = list;
                        targetlist.RemoveWithConfirm(deletedCellView);
                    targetView.ClosenGridViews = list;
                }
            }
        }
    }
}