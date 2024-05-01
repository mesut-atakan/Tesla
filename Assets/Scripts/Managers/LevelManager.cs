using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    private static bool _pauseGame = false;

    public GameObject pauseMenu;
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

    public static void GamePause(bool gameStop)
    {
        if (gameStop)
        {
            Time.timeScale = 0;
            _pauseGame = true;
        }
        else
        {
            Time.timeScale = 1;
            _pauseGame = false;
        }
    }





    public void PauseGame()
    {
        _pauseGame = !_pauseGame;
        GamePause(_pauseGame);
        Debug.Log("PauseGame");
        if (pauseMenu != null)
        {
            Debug.Log("PauseGameSetActive");
            this.pauseMenu.SetActive(_pauseGame);
        }
    }
}