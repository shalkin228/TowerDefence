using TowerDefence.Gameplay.Entity;
using UnityEngine;

namespace TowerDefence.Gameplay.Grid
{
    public class TowerGridTile : MonoBehaviour, ICursorInteractable, IEntityPlace
    {
        private bool _isOpen = true;

        public bool CanBePlaced()
        {
            return _isOpen;
        }

        public void Place(EntityFabric entityFabric, Vector3 position)
        {
            entityFabric.Spawn(transform.position, Quaternion.identity);

            _isOpen = false;
        }

        public void OnCursorEnter()
        {
            
        }

        public void OnCursorLeave()
        {
            
        }
    }
}
