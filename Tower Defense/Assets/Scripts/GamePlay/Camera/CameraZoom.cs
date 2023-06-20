using TowerDefence.Input;
using UnityEngine;
using System;

namespace TowerDefence.Gameplay.Camera
{
    public class CameraZoom : MonoBehaviour
    {
        [SerializeField] private float _speed = 100;
        [SerializeField] private float _stepWidth = 0.5f;
        [SerializeField] private float _maxZoom = 5;
        [SerializeField] private float _minZoom = 0;
        private Transform _childCamera;
        private IInputService _inputService;
        private float _zoomAmount;
        private float _smoothZoomAmount;
        private float _velocity;


        private void Start()
        {
            _inputService = ServiceLocator.Get<IInputService>();
            _childCamera = FindCameraInChilds();
        }

        private Transform FindCameraInChilds()
        {
            return GetComponentInChildren<UnityEngine.Camera>().transform ?? 
                throw new InvalidOperationException("Camera rig must have Camera component in childs");
        }

        private void LateUpdate()
        {
            HandleZoom(_inputService.Zoom);
        }

        private void HandleZoom(float input)
        {
            Vector3 newPosition = _childCamera.localPosition;

            _zoomAmount += input * _stepWidth;
            _zoomAmount = Mathf.Clamp01(_zoomAmount);
            _smoothZoomAmount = Mathf.SmoothDamp(_smoothZoomAmount, Mathf.Clamp01(_zoomAmount),
                ref _velocity, Time.deltaTime * _speed);
            newPosition.y = Mathf.Lerp(_minZoom, _maxZoom, _smoothZoomAmount);

            _childCamera.localPosition = newPosition;
        }
    }
}
