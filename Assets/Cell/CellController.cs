using DefaultNamespace.Grid;
using UnityEngine;

namespace DefaultNamespace.Cell
{
    public class CellController
    {
        private readonly CellView.Pool _cellPool;
        private readonly CellConfig _cellConfig;
        private readonly GridController _gridController;

        private CellView _cellView;

        public CellController(
            CellView.Pool cellPool,
            CellConfig cellConfig,
            GridController gridController)
        {
            _cellPool = cellPool;
            _cellConfig = cellConfig;
            _gridController = gridController;
        }

        public void SpawnCells(GridCellView cellView, Sprite sprite)
        {
            _cellView = _cellPool.Spawn();
            _cellView.transform.SetParent(cellView.transform,false);
            _cellView.CellImage.sprite = sprite;
        }
    }
}