using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader 
{
    public static string sceneToLoad;

    public static void LoadScene(string targetScene)
    {
        sceneToLoad = targetScene;
        SceneManager.LoadScene("Load");
    }
}
