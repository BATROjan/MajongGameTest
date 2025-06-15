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
            var dict = _gridController.GetDictionary();
            List<GridCellView> allVariantCellViews = new ();
            List<GridCellView> selectedCellViews = new ();
            
            allVariantCellViews = dict[dict.Keys.Count-1];

            foreach (var cell in allVariantCellViews.ToList())
            {
                selectedCellViews.Add(cell);
                cellQueue.Enqueue(cell);
                var dictList = dict[cell.CellDictID-1];
                if (dictList != null)
                {
                    foreach (var item in dictList)
                    {
                        var itemList = item.ClosenGridViews.ToList();
                    
                        foreach (var closenCell in item.ClosenGridViews.ToList())
                        {
                            if (closenCell == cell)
                            {
                                itemList.RemoveAll(cellB => cellB == cell);
                                if (itemList.Count == 0)
                                {
                                    allVariantCellViews.Add(cell);
                                }
                            }
                        }
                    } 
                }
                
                if (selectedCellViews.Count == 2)
                {
                    AddSpriteToCells(selectedCellViews);
                    selectedCellViews.Clear();
                }
                allVariantCellViews.RemoveAll(cellA => cellA == cell);  
            }
        }

        private void AddSpriteToCells(List<GridCellView> selectedCellViews)
        {
            var sprite = _cellConfig.GetModel(Random.Range(0, _cellConfig.GetModelLengs()));

            foreach (var item in selectedCellViews)
            {
                _cellController.SpawnCells(item, sprite.Sprite);
            }
        }
    }
}