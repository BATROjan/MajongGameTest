using System.Collections.Generic;
using System.Linq;
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
        private Dictionary<int, List<GridCellView>> _cellViews = new();
        
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
            for (int i = 0; i < gridView.Layers.Length; i++)
            {
                List<GridCellView> list = new List<GridCellView>();

                foreach (var cell in  gridView.Layers[i].GridCells.GridCellViews)
                {
                    list.Add(cell);
                }
                _cellViews.Add(i,list);
            }
        }

        public Dictionary<int, List<GridCellView>> GetDictionary()
        {
            return _cellViews;
        }

        public GridLayer[] GetGridLayers()
        {
            return gridView.Layers;
        }

        public void DeletCellFromClosenList(GridCellView deletedCellView, GridCellView targetView)
        {
            var list = targetView.ClosenGridViews.ToList();
            foreach (var cell in list.ToList())
            {
                    list.RemoveAll(cell => cell == deletedCellView);
                    targetView.ClosenGridViews = list.ToArray();
            }
        }
    }
}