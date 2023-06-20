using TowerDefence.Input;
using UnityEngine;

namespace TowerDefence.Gameplay.Camera
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 0.5f;
        [SerializeField] private float _aceleration = 5;
        private IInputService _inputService;
        private Vector3 _newPosition;

        private void Start()
        {
            _inputService = ServiceLocator.Get<IInputService>();
            _newPosition = transform.position;
        }

        private void LateUpdate()
        {
            HandleMovement(_inputService.Movement);
        }

        private void HandleMovement(Vector2 input)
        {
            _newPosition += Vector3.right * _speed * input.x;
            _newPosition += Vector3.forward * _speed * input.y;

            transform.position = Vector3.Lerp(transform.position, _newPosition, Time.deltaTime * _aceleration);
        }
    }
}
