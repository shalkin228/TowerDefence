using TowerDefence.Gameplay;
using UnityEngine;

namespace TowerDefence.Input
{
    public class CursorListener : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _raycastMaxDistance;
        private CursorHandler _cursorHandler;
        private IInputService _inputService;
        private ICursorInteractable _lastCursorInteractable;
        private UnityEngine.Camera _camera;
        private bool _isInitialized;

        public void Initialize(CursorHandler cursorHandler)
        {
            _cursorHandler = cursorHandler;

            _inputService = ServiceLocator.Get<IInputService>();
            _camera = ServiceLocator.Get<UnityEngine.Camera>();

            _isInitialized = true;
        }

        private void Start()
        {
            if (!_isInitialized) Debug.LogError($"{nameof(CursorListener)} wasn't initialized");
        }

        private void Update()
        {
            if (!_isInitialized) return;

            CursorInput cursorInput = _inputService.CursorInput;
            Ray mouseRay = _camera.ScreenPointToRay(cursorInput.Position);

            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, _raycastMaxDistance, _layerMask))
            {
                _cursorHandler.HandleCursorIfRaycastHit(hitInfo, cursorInput);
            }
            else
            {
                _cursorHandler.HandleCursor();
            }
        }
    }
}
