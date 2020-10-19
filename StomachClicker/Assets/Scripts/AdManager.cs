using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    public static AdManager manager;

    private string playStoreID = "3849749";
    private string appStoreID = "3849748";

    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";

    public bool isTargetPlayStore;
    public bool isTestAd;

    private float currVolume;

    private void Awake()
    {
        if (manager == null)
            manager = this.gameObject.GetComponent<AdManager>();
    }

    private void Start()
    {
        Advertisement.AddListener(this);
        InitializeAdvertisement();
    }

    private void InitializeAdvertisement()
    {
        if (isTargetPlayStore)
        {
            Advertisement.Initialize(playStoreID, isTestAd);            
        }
        else
        {
            Advertisement.Initialize(appStoreID, isTestAd);
        }
    }

    public void PlayInterstitialAd()
    {
        if (Advertisement.IsReady(interstitialAd))
        {
            Advertisement.Show(interstitialAd);
        }
    }

    public void PlayRewardedVidoeAdd()
    {
        if (Advertisement.IsReady(rewardedVideoAd))
        {
            Advertisement.Show(rewardedVideoAd);
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
    }

    public void OnUnityAdsDidError(string message)
    {
        //AudioManager.manager.UnmuteAll();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
       // AudioManager.manager.MuteAll();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        //AudioManager.manager.UnmuteAll();
    }
}


