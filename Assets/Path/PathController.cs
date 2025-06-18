using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Cell;
using DefaultNamespace.Grid;
using UnityEngine;

namespace DefaultNamespace.Path
{
    public class PathController
    {
        private readonly GridController _gridController;
        private readonly CellController _cellController;
        private readonly CellConfig _cellConfig;

        private Queue<GridCellView> cellQueue = new();
        public PathController(
            GridController gridController, 
            CellController cellController,
            CellConfig cellConfig)
        {
            _gridController = gridController;
            _cellController = cellController;
            _cellConfig = cellConfig;
        }

        public void SpawnPath()
        {
            var view = _gridController.GetView();
            var list = _gridController.GetListOfView();
            List<GridCellView> currentList = new();
            foreach (var cell in list)
            {
                if (cell.ClosenGridViews.Length == 0)
                {
                    currentList.Add(cell);
                }
            }
            for (int i = 0; i < list.Count/2; i++)
            {
                List<GridCellView> spawnCellViews = new();
                List<GridCellView> deleteCellViews = new();
                List<GridCellView> addCellViews = new();
                var sprite = _cellConfig.GetModel(Random.Range(0, _cellConfig.GetModelLengs()));
                
                for (int j = 0; j < 2; j++)
                { 
                    int id = Random.Range(0, currentList.Count);
                    Debug.Log(i);
                    spawnCellViews.Add(currentList[id]);
                    foreach (var closenView in currentList[id].UnderGridViews)
                    {
                        var newClosenList = closenView.ClosenGridViews.Where(x => x != currentList[id]).ToList();
                        closenView.ClosenGridViews = newClosenList.ToArray();
                            
                        if (newClosenList.Count == 0)
                        {
                            addCellViews.Add(closenView);
                        }
                    }

                    var newCurrentList = currentList.Where(x => x != currentList[id]).ToList();
                    currentList = newCurrentList;
                    
                    if (spawnCellViews.Count == 2)
                    {
                        foreach (var cell in spawnCellViews)
                        {
                            _cellController.SpawnCells(cell, sprite.Sprite);
                        }
                        currentList.AddRange(addCellViews);
                    }
                }
                
            }
        }

        private void AddSpriteToCells(GridCellView selectedCellView)
        {
            var sprite = _cellConfig.GetModel(Random.Range(0, _cellConfig.GetModelLengs()));
            _cellController.SpawnCells(selectedCellView, sprite.Sprite);
        }
    }
}