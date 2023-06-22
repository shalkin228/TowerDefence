using System.ComponentModel.Design;
using TowerDefence.Input;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDefence
{
    public class Bootstrap : MonoBehaviour
    {
        private static bool _isInitialized;

        [SerializeField, Scene] private string _sceneToLoad;

        private void Start()
        {
            if (_isInitialized)
            {
                Debug.LogError("The game has already been initialized.");

                return;
            }
            Debug.Log("Initializing game...");

            ServiceLocator.Register<IInputService>(new StandartInputService());
            ServiceLocator.Register(new GameObject(nameof(CoroutineExecuter)).AddComponent<CoroutineExecuter>());

            _isInitialized = true;

            Debug.Log("Game is initialized. Loading scene " + _sceneToLoad);
            SceneManager.LoadScene(_sceneToLoad);
        }
    }
}
