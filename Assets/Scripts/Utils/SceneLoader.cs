using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("Configuration")]
    public SceneSO sceneToLoad;
    public SceneSO currentScene;
    public LevelEntanceSO levelEntrance;
    public bool loadingScreen;


    [Header("Player Path")]
    public PlayerPathSO playerPath;

    [Header("Broadcasting events")]
    public LoadSceneRequestGameEvent loadSceneEvent;

    public void LoadScene()
    {
        if (this.levelEntrance != null && this.playerPath != null)
        {
            this.playerPath.levelEntance = this.levelEntrance;
            this.playerPath.lastScene = this.currentScene;
        }
            

        var request = new LoadSceneRequest(
            scene: this.sceneToLoad,
            loadingScreen: this.loadingScreen
        );

        this.loadSceneEvent.Raise(request);
    }
}
