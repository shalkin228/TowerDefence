using UnityEngine;

namespace TowerDefence.Gameplay.Entity
{
    [CreateAssetMenu(fileName = "New Entity")]
    public class EntityFabric : ScriptableObject
    {
        public Texture2D Icon { get { return _icon; } }
        public string Name { get { return _name; } }

        [SerializeField] private Texture2D _icon;
        [SerializeField] private string _name;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Vector3 _spawnOffset;

        public GameObject Spawn(Vector3 position, Quaternion rotation)
        {
            position += _spawnOffset;
            return Instantiate(_prefab, position, rotation);
        }
    }
}
