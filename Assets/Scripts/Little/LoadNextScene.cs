using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    [SerializeField] private LoadingSceneSystem loadingSceneSystem;

    private void Start()
    {
        StartCoroutine(LoadingScreen());
    }
   
    IEnumerator LoadingScreen()
    {
        yield return new WaitForSeconds(1f);
        loadingSceneSystem.LoadSceneInSync("Interface");

    }
}
