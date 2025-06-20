﻿using System;
using System.Collections.Generic;
using DefaultNamespace.Grid;
using UnityEngine;

namespace DefaultNamespace.Cell
{
    public class CellController
    {
        public Action<List<GridCellView>> OnActiveCells;
        private readonly CellView.Pool _cellPool;
        private readonly CellConfig _cellConfig;
        private readonly GridController _gridController;

        private CellView _cellView;
        private CellView _fistCell;
        private CellView _secondCell;

        private List<GridCellView> _despawnCellViews = new List<GridCellView>();
        private List<CellView> _allCellViews = new();
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
            _allCellViews.Add(_cellView);
            _cellView.transform.SetParent(cellView.transform,false);
            cellView.CellView = _cellView;
            _cellView.CellImage.sprite = model.Sprite;
            _cellView.CellType = model.CellType;
            _cellView.ParentGridCellView = cellView;
            _cellView.OnCellSelected += CheckCell;
        }

        public void CheckCell(CellView cellView)
        {
            if (!_fistCell)
            {
                _fistCell = cellView;
                _despawnCellViews.Add(_fistCell.ParentGridCellView);
            }
            else if(_fistCell != cellView)
            {
                _secondCell = cellView;
                _despawnCellViews.Add(_secondCell.ParentGridCellView);
                if (_fistCell.CellType == _secondCell.CellType)
                {
                    _cellPool.Despawn(_fistCell);
                    _allCellViews.Remove(_fistCell);
                    _cellPool.Despawn(_secondCell);
                    _allCellViews.Remove(_secondCell);
                    OnActiveCells?.Invoke(_despawnCellViews);
                }

                _despawnCellViews.Clear();
                _fistCell = null;
                _secondCell = null; 
            }
        }

        public void DespawAllCells()
        {
            foreach (var cell in _allCellViews)
            {
                _cellView.OnCellSelected -= CheckCell;
                _cellPool.Despawn(cell);
            }
            _allCellViews.Clear();
        }
    }
}