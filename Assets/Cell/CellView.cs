using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DefaultNamespace.Cell
{
    public class CellView : MonoBehaviour
    {
        public Image CellImage
        {
            get
            {
                return cellImage;
            }
            set
            {
                cellImage = value;
            }
        }
       [SerializeField] private Image cellImage;
        public class  Pool : MonoMemoryPool<CellView>
        {
            
        }
    }
}