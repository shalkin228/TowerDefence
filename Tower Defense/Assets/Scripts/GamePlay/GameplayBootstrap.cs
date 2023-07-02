using TowerDefence.Gameplay.Camera;
using TowerDefence.Gameplay.Entity;
using TowerDefence.Gameplay.Entity.Tower;
using TowerDefence.Input;
using UnityEngine;

namespace TowerDefence.Gameplay
{
    public class GameplayBootstrap : MonoBehaviour
    {
        private static bool _isInitialized;
        [SerializeField] private CameraSpawnPoint _cameraSpawnPoint;
        [SerializeField] private CursorListener _cursorListenerPrefab;

        private void Awake()
        {
            if (_isInitialized)
            {
                Debug.LogError("There's 2 or more instances of " + nameof(GameplayBootstrap) + " in the scene.");
                return;
            }

            _cameraSpawnPoint.Spawn();
            ServiceLocator.Register<EntityFabricSelector>(new TowerFabricSelector());
            Instantiate(_cursorListenerPrefab).Initialize(new EntityPlaceCursorHandler());

            _isInitialized = true;
        }
    }
}
