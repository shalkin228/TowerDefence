using UnityEngine;

namespace TowerDefence.Gameplay.Camera
{
    public class CameraSpawnPoint : MonoBehaviour
    {
        [SerializeField] private Vector3 _spawnOffset;
        [SerializeField] private GameObject _camera;

        public void Spawn()
        {
            Instantiate(_camera, transform.position + _spawnOffset, _camera.transform.rotation);
        }
    }
}
