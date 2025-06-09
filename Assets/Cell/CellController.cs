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

        public void SpawnCells()
        {
            var sprite = _cellConfig.GetModel(Random.Range(0, _cellConfig.GetModelLengs()));
            
            var gridLayers = _gridController.GetGridLayers();
            for (int i = 0; i < gridLayers.Length; i++)
            {
                var cellTransform = gridLayers[i].GridCells.CellsTransforms;
                for (int j = 0; j < cellTransform.Length; j++)
                {
                    _cellView = _cellPool.Spawn();
                    _cellView.transform.SetParent(cellTransform[j],false);
                    _cellView.CellImage.sprite = sprite.Sprite;
                }
            }
        }
    }
}