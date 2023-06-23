using TowerDefence.Input;
using UnityEngine;

namespace TowerDefence.Gameplay
{
    public class CursorListener : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _raycastMaxDistance;
        private IInputService _inputService;
        private ICursorInteractable _lastCursorInteractable;
        private UnityEngine.Camera _camera;

        private void Start()
        {
            _inputService = ServiceLocator.Get<IInputService>();
            _camera = ServiceLocator.Get<UnityEngine.Camera>();
        }

        private void Update()
        {
            CursorData cursorData = _inputService.CursorData;
            Ray mouseRay = _camera.ScreenPointToRay(cursorData.Position);

            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, _raycastMaxDistance, _layerMask))
            {
                HandleRaycast(hitInfo, cursorData);
            }
            else
            {
                _lastCursorInteractable?.OnCursorLeave();
                _lastCursorInteractable = null;
            }
        }

        private void HandleRaycast(RaycastHit hitInfo, CursorData cursorData)
        {
            if (!hitInfo.collider.TryGetComponent(out ICursorInteractable cursorInteractable)) return;

            if (_lastCursorInteractable != cursorInteractable)
            {
                _lastCursorInteractable?.OnCursorLeave();
                cursorInteractable.OnCursorEnter();

                _lastCursorInteractable = cursorInteractable;
            }

            if (cursorData.WasPressedThisFrame)
            {
                cursorInteractable.OnCursorClick(hitInfo.point);
            }
        }
    }
}
