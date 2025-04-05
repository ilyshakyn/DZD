using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static string sceneToLoad;
    public void OnStartGame()
    {
        SceneLoader.LoadScene("Level1");
    }
    public static void LoadScene(string targetScene)
    {

        sceneToLoad = targetScene;
        SceneManager.LoadScene("Load");
    }
    public void RestartScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game"); 
        Application.Quit();
    }
}
