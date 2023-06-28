using UnityEngine;

namespace TowerDefence.Gameplay.Entity
{
    public class TowerFabricSelector : EntityFabricSelector
    {
        private readonly string _EntityListPath = "Entity Lists/TowerEntityList";

        protected override EntityFabricList GetEntityList()
        {
            return Resources.Load<EntityFabricList>(_EntityListPath);
        }
    }
}
