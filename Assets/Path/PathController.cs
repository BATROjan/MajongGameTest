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
            for (int i = 0; i < list.Count; i++)
            {

                var sprite = _cellConfig.GetModel(Random.Range(0, _cellConfig.GetModelLengs()));
                
                for (int j = 0; j < 2; j++)
                {
                    foreach (var cell in currentList.ToList())
                    {
                        var sss = currentList.Where(x => x != cell).ToList();

                        _cellController.SpawnCells(cell, sprite.Sprite);
                        foreach (var closenView in cell.UnderGridViews)
                        {
                            // Создаем новый список без текущего cell
                            var newClosenList = closenView.ClosenGridViews.Where(x => x != cell).ToList();
                            // Здесь нужно как-то обновить ClosenGridViews в closenView,
                            // но это зависит от того, как у вас реализована структура данных
                            // Например, если ClosenGridViews - это свойство с сеттером:
                            // closenView.ClosenGridViews = newClosenList.ToArray();
                            closenView.ClosenGridViews = newClosenList.ToArray();
                            if (newClosenList.Count == 0)
                            {
                                currentList.Add(closenView);
                            }
                        }
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