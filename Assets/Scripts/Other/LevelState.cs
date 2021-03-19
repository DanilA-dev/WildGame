using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelState : MonoBehaviour
{
    private void Start()
    {
        CheckCurrentScene();
        Time.timeScale = 1;
    }
    public static void LoadLevel(int levelIndex) => SceneManager.LoadScene(levelIndex);

    public void LoadLocalLevel(int levelIndex) => SceneManager.LoadScene(levelIndex);

    public static void ReloadLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public static void CheckCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = "VictoryScene";
        if(currentScene.name == sceneName)
        {
            GlobalEvents.instance.gameState = GameState.Victory;
        }
    }

    public void QuitApp() => Application.Quit();
   
}
