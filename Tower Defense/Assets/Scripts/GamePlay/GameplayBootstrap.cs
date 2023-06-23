using TowerDefence.Gameplay.Camera;
using UnityEngine;

namespace TowerDefence.Gameplay
{
    public class GameplayBootstrap : MonoBehaviour
    {
        [SerializeField] private CameraSpawnPoint _cameraSpawnPoint;

        private void Awake()
        {

            _cameraSpawnPoint.Spawn();
        }
    }
}
