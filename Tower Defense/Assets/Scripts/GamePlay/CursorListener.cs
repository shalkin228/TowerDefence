using TowerDefence.Input;
using UnityEngine;

namespace TowerDefence.Gameplay
{
    public class CursorListener : MonoBehaviour
    {
        private IInputService _inputService;

        private void Start()
        {
            _inputService = ServiceLocator.Get<IInputService>();
        }

        private void Update()
        {
            //UnityEngine.Camera.current
        }
    }
}
