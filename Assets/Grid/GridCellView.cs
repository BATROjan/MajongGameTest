using UnityEngine;

namespace DefaultNamespace.Grid
{
    public class GridCellView : MonoBehaviour
    {
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
    }
}