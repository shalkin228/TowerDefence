using UnityEngine;

namespace TowerDefence.Input
{
    public interface IInputService
    {
        Vector2 Movement { get; }
        float Zoom { get; }
        CursorData CursorData { get; }  
    }

    public struct CursorData
    {
        public Vector2 Position;
        public bool WasPressedThisFrame;
    }
}
