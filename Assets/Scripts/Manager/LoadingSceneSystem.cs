using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneSystem : MonoBehaviour
{
    [SerializeField] GameObject loadingScreen;
    [SerializeField] Slider slider;
    [SerializeField] Text progressText;
    public void LoadSceneInSync(string scene)
    {
        StartCoroutine(LoadAsynchronously(scene));
    }


    IEnumerator LoadAsynchronously(string scene)
    {
        loadingScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);


        while (!operation.isDone)
        {

            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progress = progress * 100f;
            progressText.text = progress.ToString("F0") + "%";
            yield return null;
        }
    }
}
