using UnityEngine;

namespace TowerDefence.Gameplay.Entity
{
    public class TowerFabricSelector : EntityFabricSelector
    {
        private readonly string _EntityListPath = "Entity Lists/TowerFabricList";

        protected override bool _needLogs { get { return false; } }

        protected override EntityFabricList GetEntityList()
        {
            return Resources.Load<EntityFabricList>(_EntityListPath);
        }
    }
}
