using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public static void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void ChangeScene(byte sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
}