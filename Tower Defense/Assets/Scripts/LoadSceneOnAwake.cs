using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDefence
{
    //Just dev tool in case you're lazy to always switch scene
    public class LoadSceneOnAwake : MonoBehaviour
    {
        private static bool _hasLoadedScene;//This script should load scene only once
        [SerializeField, Scene] private string _sceneToLoad;

        private void Awake()
        {
            if (!Application.isEditor | _hasLoadedScene) { Destroy(gameObject); return; }

            _hasLoadedScene = true;
            SceneManager.LoadScene(_sceneToLoad);
        }
    }
}
