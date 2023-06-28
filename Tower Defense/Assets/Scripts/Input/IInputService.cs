using System;
using UnityEngine;

namespace TowerDefence.Input
{
    public interface IInputService
    {
        Vector2 Movement { get; }
        float Zoom { get; }
        CursorInput CursorInput { get; }
        event Action OnNextEntityButton;
        event Action OnPreviousEntityButton;
    }

    public struct CursorInput
    {
        public Vector2 Position;
        public bool WasPressedThisFrame;
    }
}
