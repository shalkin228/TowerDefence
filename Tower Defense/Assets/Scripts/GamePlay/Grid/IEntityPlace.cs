using TowerDefence.Gameplay.Entity;
using UnityEngine;

namespace TowerDefence.Gameplay.Grid
{
    public interface IEntityPlace
    {
        void Place(EntityFabric entityFabric, Vector3 position);
        bool CanBePlaced();
    }
}
