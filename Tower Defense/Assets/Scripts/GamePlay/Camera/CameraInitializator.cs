using UnityEngine;

namespace TowerDefence.Gameplay.Camera
{
    public class CameraInitializator : MonoBehaviour
    {
        private void OnEnable()
        {
            ServiceLocator.Register(GetComponentInChildren<UnityEngine.Camera>());
        }

        private void OnDisable()
        {
            ServiceLocator.Unregister<UnityEngine.Camera>();
        }
    }
}
