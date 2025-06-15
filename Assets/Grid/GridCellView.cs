using UnityEngine;

namespace DefaultNamespace.Grid
{
    public class GridCellView : MonoBehaviour
    {
        public int CellDictID => cellDictID;
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

        [SerializeField] private GridCellView[] closenGridViews;
        [SerializeField] private int cellDictID;
    }
}