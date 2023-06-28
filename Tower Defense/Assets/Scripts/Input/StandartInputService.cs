using System;
using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TowerDefence.Input
{
    //Do not destroy this object!
    public class StandartInputService : IInputService
    {
        public Vector2 Movement => FormatVector(_controls.Camera.Movement.ReadValue<Vector2>());
        public float Zoom => FormatFloat(_controls.Camera.Zoom.ReadValue<Vector2>().y);
        public CursorInput CursorInput => GetCursorInput();
        public event Action OnNextEntityButton 
        { 
            add => _onNextEntityButton += value; 
            remove => _onNextEntityButton -= value;
        }
        public event Action OnPreviousEntityButton 
        { 
            add => _onPreviousEntityButton += value; 
            remove => _onPreviousEntityButton -= value;
        }
        public event Action<int> OnEntityIndexButton
        {
            add => _onEntityIndexButton += value;
            remove => _onEntityIndexButton -= value;
        }

        private Action _onNextEntityButton;
        private Action _onPreviousEntityButton;
        private Action<int> _onEntityIndexButton;
        private Controls _controls = new Controls();
        private readonly char[] _numbers = { '1', '2', '3', '4', '5', '6', '7', '8', '9'};

        public StandartInputService()
        {
            _controls.Enable();

            _controls.SelectEntity.NextEntity.performed += ctx => _onNextEntityButton?.Invoke();
            _controls.SelectEntity.PreviousEntity.performed += ctx => _onPreviousEntityButton?.Invoke();

            Keyboard.current.onTextInput += c =>
            {
                if (IsNumber(c, out int num))
                {
                    _onEntityIndexButton?.Invoke(num);
                }
            };
        }

        private bool IsNumber(char c, out int i)
        {
            i = 0;

            foreach(char number in _numbers)
            {
                if (c == number)
                {
                    i = int.Parse(number.ToString());
                    return true;
                }
            }

            return false;
        }

        private CursorInput GetCursorInput()
        {
            return new CursorInput
            {
                Position = _controls.Cursor.Position.ReadValue<Vector2>(),
                WasPressedThisFrame = _controls.Cursor.Interact.WasPerformedThisFrame()
            };
        }

        private Vector2 FormatVector(Vector2 value)
        {
            value.x = FormatFloat(value.x);
            value.y = FormatFloat(value.y);
            return value;
        }

        private float FormatFloat(float value)
        { 
            if (value == 0) { return 0; }
            return value > 0 ? 1 : -1;
        }
    }
}
