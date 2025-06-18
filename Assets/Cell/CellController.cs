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
        private CellView _fistCell;
        private CellView _secondCell;

        public CellController(
            CellView.Pool cellPool,
            CellConfig cellConfig,
            GridController gridController)
        {
            _cellPool = cellPool;
            _cellConfig = cellConfig;
            _gridController = gridController;
        }

        public void SpawnCells(GridCellView cellView, CellModel model)
        {
            _cellView = _cellPool.Spawn();
            _cellView.transform.SetParent(cellView.transform,false);
            cellView.CellView = _cellView;
            _cellView.CellImage.sprite = model.Sprite;
            _cellView.CellType = model.CellType;
            _cellView.OnCellSelected += CheckCell;
        }

        public void CheckCell(CellView cellView)
        {
            if (!_fistCell)
            {
                _fistCell = cellView;
            }
            else if(_fistCell != cellView)
            {
                _secondCell = cellView;
                if (_fistCell.CellType == _secondCell.CellType)
                {
                    _cellPool.Despawn(_fistCell);
                    _cellPool.Despawn(_secondCell);
                    
                    _fistCell = null;
                    _secondCell = null;
                }
            }
        }
    }
}