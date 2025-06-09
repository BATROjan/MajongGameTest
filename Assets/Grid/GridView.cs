using System;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace DefaultNamespace.Grid
{
    public class GridView :MonoBehaviour
    {
        public GridLayer[] Layers => layers;
       

        [SerializeField] private GridLayer[] layers;
        
        public class Pool : MonoMemoryPool<GridView>
        {
        
        }
    }

    [Serializable]
    public class GridLayer
    {
        public int LayerNumber;
        public GridCells GridCells;
    }
    [Serializable]
    public struct GridCells
    {
        public GridCellView[] GridCellViews;
    }
}