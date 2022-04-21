using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsTools: MonoBehaviour, IAdsShower ,IUnityAdsListener
{
    private const string InterstitialPlacement = "Interstitial_Android";
    private const string RewardedPlacement = "Rewarded_Android";
    private const string GameId = "4710222";
    private bool _isReady = false;

    private Action _onRewardedFinish;

    public void Start()
    {
        Advertisement.Initialize(GameId, true, true, this);
    }
    public void OnUnityAdsDidError(string message)
    {
        _onRewardedFinish = null;
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
            _onRewardedFinish?.Invoke();
        _onRewardedFinish = null;
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }

    public void OnUnityAdsReady(string placementId)
    {
        _isReady = true;
    }

    public void ShowInterstitial()
    {
        if (!_isReady)
            return;
        Advertisement.Show(InterstitialPlacement);
    }

    public void ShowVidio(Action successShow)
    {
        if (!_isReady)
            return;
        Advertisement.Show(RewardedPlacement);
        _onRewardedFinish = successShow;
    }
}