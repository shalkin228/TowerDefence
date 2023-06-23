using UnityEngine;

namespace TowerDefence.Gameplay.Entity
{
    public abstract class Entity : ScriptableObject
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Vector3 _spawnOffset;
    }
}
