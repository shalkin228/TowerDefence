using UnityEngine;

namespace TowerDefence.Input
{
    public interface IInputService
    {
        Vector2 Movement { get; }
        float Zoom { get; }
    }
}
