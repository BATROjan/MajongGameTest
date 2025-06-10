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
            for (int i = dict.Keys.Count-1; i > 0; i--)
            {
                var lastList = dict[i];
                List<GridCellView> selectedCellViews = new List<GridCellView>();
                foreach (var cell in dict[i].ToList())
                {
                    if (dict[i].Count % 2 ==0)
                    {
                        selectedCellViews.Add(cell);
                        if (selectedCellViews.Count == 2)
                        {
                            var sprite = _cellConfig.GetModel(Random.Range(0, _cellConfig.GetModelLengs()));

                            foreach (var item in selectedCellViews)
                            {
                                _cellController.SpawnCells(item, sprite.Sprite);
                            }
                        }
                        lastList.RemoveAll(cell => cell == cell);  
                    }
                }
            }
            
        }
    }
}