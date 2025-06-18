using DefaultNamespace.Cell;
using UnityEngine;

namespace DefaultNamespace.Grid
{
    public class GridCellView : MonoBehaviour
    {
        public GridCellView[] UnderGridViews => underGridViews;
        
        public GridCellView[] ClosenGridViews
        {
            get
            {
                return closenGridViews;
            }
            set
            {
                closenGridViews = value;
            }
        }    
        public GridCellView[] CloneCloseGridViews
        {
            get
            {
                return cloneCloseGridViews;
            }
            set
            {
                cloneCloseGridViews = value;
            }
        } 
        public CellView CellView
        {
            get
            {
                return cellViews;
            }
            set
            {
                cellViews = value;
            }
        }

        [SerializeField] private GridCellView[] closenGridViews;
        [SerializeField] private GridCellView[] underGridViews;
        private CellView cellViews;
        private GridCellView[] cloneCloseGridViews;
    }
}