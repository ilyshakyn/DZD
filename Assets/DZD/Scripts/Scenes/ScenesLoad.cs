using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
using System.Threading;


public class ScenesLoad : MonoBehaviour
{
    public Slider progressBar;
  

    [SerializeField] private string defaultScene = "MainMenu";

    void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        string targetScene = string.IsNullOrEmpty(SceneLoader.sceneToLoad) ? defaultScene : SceneLoader.sceneToLoad;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(targetScene);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            progressBar.value = progress;
            

            if (asyncLoad.progress >= 0.9f)
            {
                progressBar.value = 1f;
              
                yield return new WaitForSeconds(0.5f);
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
