using UnityEngine;

namespace TowerDefence.Gameplay
{
    public interface IClickable
    {
        void OnMouseHover();
        void OnMouseLeave();
        void OnMouseClick(Vector3 clickHitPosition);
    }
}
