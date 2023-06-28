using UnityEditor.SceneManagement;
using UnityEditor;

namespace TowerDefence
{
    [InitializeOnLoad]
    public class SetStartScene
    {
        static SetStartScene()
        {
            EditorSceneManager.playModeStartScene = AssetDatabase.LoadAssetAtPath<SceneAsset>("Assets/Scenes/Initialize.unity");
        }
    }
}
