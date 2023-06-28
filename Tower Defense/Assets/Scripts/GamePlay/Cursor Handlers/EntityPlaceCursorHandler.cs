using TowerDefence.Gameplay.Entity;
using TowerDefence.Gameplay.Grid;
using UnityEngine;

namespace TowerDefence.Gameplay
{
    public class EntityPlaceCursorHandler : CursorHandler
    {
        private EntityFabricSelector _entityFabricSelector => ServiceLocator.Get<EntityFabricSelector>();

        protected override bool CanCursorInteractableBeHandled(ICursorInteractable cursorInteractable)
        {
            return cursorInteractable is IEntityPlace;
        }

        protected override void OnCursorClick(CursorClickHit cursorClickHit)
        {
            IEntityPlace entityPlace = cursorClickHit.Target as IEntityPlace;

            if (!entityPlace.CanBePlaced()) return;

            entityPlace.Place(GetSelectedEntityFabric(cursorClickHit.Point), cursorClickHit.Point);
        }

        private EntityFabric GetSelectedEntityFabric(Vector3 position)
        {
            return _entityFabricSelector.CurrentEntity;
        }
    }
}
