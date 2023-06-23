using UnityEngine;

namespace TowerDefence.Gameplay
{
    public interface ICursorInteractable
    {
        void OnCursorEnter();
        void OnCursorLeave();
        void OnCursorClick(Vector3 clickHitPosition);
    }
}
