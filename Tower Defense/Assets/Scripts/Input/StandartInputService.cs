using UnityEngine;

namespace TowerDefence.Input
{
    //Do not destroy this object!
    public class StandartInputService : IInputService
    {
        public Vector2 Movement => FormatVector(_controls.Camera.Movement.ReadValue<Vector2>());
        public float Zoom => FormatFloat(_controls.Camera.Zoom.ReadValue<Vector2>().y);

        private Controls _controls = new Controls();

        public StandartInputService()
        {
            _controls.Enable();

            Application.quitting += _controls.Disable;
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
