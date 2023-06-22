using UnityEngine;

namespace TowerDefence.Input
{
    public interface IInputService
    {
        Vector2 Movement { get; }
        float Zoom { get; }
        Cursor Cursor { get; }  
    }

    public struct Cursor
    {
        public Vector2 Position;
        public bool WasPressedThisFrame;
    }
}
