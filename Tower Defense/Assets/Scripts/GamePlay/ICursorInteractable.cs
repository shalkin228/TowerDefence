using UnityEngine;

namespace TowerDefence.Gameplay
{
    public interface ICursorInteractable
    {
        void OnCursorHover();
        void OnCursorLeave();
        void OnCursorClick(Vector3 clickHitPosition);
    }
}
