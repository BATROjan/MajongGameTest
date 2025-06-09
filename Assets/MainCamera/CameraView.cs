using UnityEngine;

namespace MainCamera
{
    public class CameraView: MonoBehaviour
    {
        public UnityEngine.Camera MainCamera => mainCamera;
        
        [SerializeField] private UnityEngine.Camera mainCamera;
    }
}