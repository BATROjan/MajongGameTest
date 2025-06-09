using UnityEngine;


    public class UIRoot : MonoBehaviour, IUIRoot
    {
        public Transform ActivateContainer => activateContainer;
        public Transform DeativateContainer => deactivateContainer;
        public Canvas RootCanvas => canvas;
        
        [SerializeField] private Canvas canvas;
        [SerializeField] private Transform activateContainer;
        [SerializeField] private Transform deactivateContainer;
    }
