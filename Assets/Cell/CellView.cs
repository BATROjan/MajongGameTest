using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DefaultNamespace.Cell
{
    public class CellView : UIButton
    {
        public Image BlackOut => blackOut;
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
       [SerializeField] private Image blackOut;
        public class  Pool : MonoMemoryPool<CellView>
        {
            
        }
    }
}