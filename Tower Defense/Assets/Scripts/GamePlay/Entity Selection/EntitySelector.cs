using UnityEditor.Search;
using UnityEngine;

namespace TowerDefence.Gameplay.Entity
{
    public abstract class EntitySelector : MonoBehaviour
    {
        private ParsedQuery<IEntity> _entities;
    }

    public interface IEntity
    {
        Texture2D Icon { get; }
        string Name { get; }

        void Spawn();
    }
}
