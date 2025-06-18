using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Cell;
using DefaultNamespace.Grid;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace.Path
{
    public class PathController
    {
        private readonly GridController _gridController;
        private readonly CellController _cellController;
        private readonly CellConfig _cellConfig;

        Dictionary<GridCellView, List<GridCellView>> dictionary = new ();
        List<GridCellView> _currentList = new();
        public PathController(
            GridController gridController, 
            CellController cellController,
            CellConfig cellConfig)
        {
            _gridController = gridController;
            _cellController = cellController;
            _cellConfig = cellConfig;
            cellController.OnActiveCells += ActiveNewCells;
        }

        public void SpawnPath()
        {
            _currentList = new();
            dictionary = new ();
            var list = _gridController.GetListOfView();
            
            foreach (var cell in list)
            {
                dictionary.Add(cell, cell.UnderGridViews.ToList());
                cell.CloneCloseGridViews = cell.ClosenGridViews;
                if (cell.ClosenGridViews.Length == 0)
                {
                    _currentList.Add(cell);
                }
            }
            for (int i = 0; i < list.Count/2; i++)
            {
                List<GridCellView> spawnCellViews = new();
                List<GridCellView> addCellViews = new();
                var model = _cellConfig.GetModel(Random.Range(0, _cellConfig.GetModelLengs()));
                
                for (int j = 0; j < 2; j++)
                { 
                    int id = Random.Range(0, _currentList.Count);
                    Debug.Log(i);
                    spawnCellViews.Add(_currentList[id]);
                    foreach (var closenView in _currentList[id].UnderGridViews)
                    {
                        var newClosenList = closenView.ClosenGridViews.Where(x => x != _currentList[id]).ToList();
                        closenView.ClosenGridViews = newClosenList.ToArray();
                            
                        if (newClosenList.Count == 0)
                        {
                            addCellViews.Add(closenView);
                        }
                    }

                    var newCurrentList = _currentList.Where(x => x != _currentList[id]).ToList();
                    _currentList = newCurrentList;
                    
                    if (spawnCellViews.Count == 2)
                    {
                        foreach (var cell in spawnCellViews)
                        {
                            _cellController.SpawnCells(cell, model);
                        }
                        _currentList.AddRange(addCellViews);
                    }
                }
                
            }
            foreach (var cell in list)
            {
                cell.ClosenGridViews = cell.CloneCloseGridViews;
                if (cell.ClosenGridViews.Length == 0)
                {
                    cell.CellView.BlackOut.gameObject.SetActive(false);
                    _currentList.Add(cell);
                }
            }
        }

        private void ActiveNewCells(List<GridCellView> cellViews)
        {
            for (int i = 0; i < cellViews.Count; i++)
            {
                foreach (var closenView in cellViews[i].UnderGridViews)
                {
                    var newClosenList = closenView.ClosenGridViews.Where(x => x != cellViews[i]).ToList();
                    closenView.ClosenGridViews = newClosenList.ToArray();
                            
                    if (newClosenList.Count == 0)
                    {
                        closenView.CellView.BlackOut.gameObject.SetActive(false);
                    }
                } 
            }
        }

        public void ResetLvL()
        {
            _gridController.DespawnGrid();
            _cellController.DespawAllCells();
            
            _gridController.SpawnGrid();
            SpawnPath();
        }
    }
}