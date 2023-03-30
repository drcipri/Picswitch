using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AdsManager1 : MonoBehaviour, IUnityAdsListener
{
#if UNITY_IOS
    private string gameId = "4675724";
    private string myPlacementId = "Rewarded_iOS";
#elif UNITY_ANDROID
    private string gameId = "4675725";
    private string myPlacementId = "Rewarded_Android";
#endif

    
    [SerializeField] private Hint hintCS;
    
    
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
        if(showResult == ShowResult.Finished)
        {
            hintCS.SetHintFromAdsTrue();
            hintCS.gameObject.SetActive(true);
            
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.Log("Ad was skiped, reward failed");
        }
        else if (showResult != ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an eror.");
        }
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
