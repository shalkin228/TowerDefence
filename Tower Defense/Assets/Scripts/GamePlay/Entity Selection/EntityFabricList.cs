using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Gameplay.Entity
{
    [CreateAssetMenu(fileName = "New Entity List")]
    public class EntityFabricList : ScriptableObject
    {
        public List<EntityFabric> List { get { return _list; } }
        [SerializeField] private List<EntityFabric> _list;
    }
}
