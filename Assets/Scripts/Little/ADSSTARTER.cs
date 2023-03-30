using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ADSSTARTER : MonoBehaviour, IUnityAdsListener
{
#if UNITY_IOS
    private string gameId = "4675724";
    private string myPlacementId = "Rewarded_iOS";
#elif UNITY_ANDROID
    private string gameId = "4675725";
    private string myPlacementId = "Rewarded_Android";
#endif


    


    private bool testMode = true;
    private Button adsButton;

    private void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
    private void OnDisable()
    {
        Advertisement.RemoveListener(this);
    }
    private void OnEnable()
    {
        Advertisement.AddListener(this);
    }


    private void Start()
    {
        adsButton = GetComponent<Button>();
        adsButton.interactable = Advertisement.IsReady(myPlacementId);
        if (adsButton) adsButton.onClick.AddListener(ShowRewardedVideo);
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
        gameObject.SetActive(false);
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log(message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //ads start

    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
      
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == myPlacementId)
        {
            adsButton.interactable = true;
        }
    }


    private void ShowRewardedVideo()
    {
        Advertisement.Show(myPlacementId);
    }
}

