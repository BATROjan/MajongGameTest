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
        private GridView _gridView;
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
            _gridView = _gridPool.Spawn();
            _gridView.gameObject.transform.SetParent(_uiService.Get<GameWindowView>().transform, false);
            for (int i = 0; i < _gridView.Layers.Length; i++)
            {
                List<GridCellView> list = new List<GridCellView>();

                foreach (var cell in  _gridView.Layers[i].GridCells.GridCellViews)
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

        public GridView GetView()
        {
            return _gridView;
        }

        public GridLayer[] GetGridLayers()
        {
            return _gridView.Layers;
        }

        public int GetCellCount()
        {
            int count = 0;
            foreach (var layer in _gridView.Layers)
            {
                count += layer.GridCells.GridCellViews.Length;
            }
            return count;
        }

        public List<GridCellView> GetListOfView()
        {
            List<GridCellView> list = new();
            foreach (var layer in _gridView.Layers)
            {
                list.AddRange(layer.GridCells.GridCellViews);
            }
            return list;
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