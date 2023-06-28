using TowerDefence.Input;
using UnityEngine;

namespace TowerDefence.Gameplay
{
    public abstract class CursorHandler
    {
        private ICursorInteractable _lastCursorInteractable;

        public void HandleCursorIfRaycastHit(RaycastHit hitInfo, CursorInput cursorInput)
        {
            if (!hitInfo.collider.TryGetComponent(out ICursorInteractable cursorInteractable)) return;
            if (!CanCursorInteractableBeHandled(cursorInteractable)) return;

            if (_lastCursorInteractable != cursorInteractable)
            {
                _lastCursorInteractable?.OnCursorLeave();
                cursorInteractable.OnCursorEnter();

                _lastCursorInteractable = cursorInteractable;
            }

            if (cursorInput.WasPressedThisFrame)
            {
                OnCursorClick(new CursorClickHit(cursorInteractable, hitInfo.point)); 
            }
        }

        public void HandleCursor()
        {
            _lastCursorInteractable?.OnCursorLeave();
            _lastCursorInteractable = null;
        }

        protected abstract bool CanCursorInteractableBeHandled(ICursorInteractable cursorInteractable);

        protected abstract void OnCursorClick(CursorClickHit cursorClickHit);
    }

    public struct CursorClickHit
    {
        public ICursorInteractable Target { get; private set; }
        public Vector3 Point { get; private set; }

        public CursorClickHit(ICursorInteractable target, Vector3 point)
        {
            Target = target;
            Point = point;
        }
    }
}
