using TowerDefence.Gameplay.Camera;
using TowerDefence.Gameplay.Entity;
using TowerDefence.Input;
using UnityEngine;

namespace TowerDefence.Gameplay
{
    public class GameplayBootstrap : MonoBehaviour
    {
        [SerializeField] private CameraSpawnPoint _cameraSpawnPoint;
        [SerializeField] private CursorListener _cursorListenerPrefab;

        private void Awake()
        {
            _cameraSpawnPoint.Spawn();
            ServiceLocator.Register<EntityFabricSelector>(new TowerFabricSelector());
            Instantiate(_cursorListenerPrefab).Initialize(new EntityPlaceCursorHandler());
        }
    }
}
