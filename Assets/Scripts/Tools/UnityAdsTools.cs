using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsTools: MonoBehaviour, IAdsShower ,IUnityAdsListener, IUnityAdsInitializationListener
{
    private const string InterstitialPlacement = "Interstitial_Android";
    private const string RewardedPlacement = "Rewarded_Android";
    private const string GameId = "4723715";
    private bool _isReady = false;

    private Action _onRewardedFinish;
    public void Start()
    {
        UnityAdsTools unityAdsTools = this;
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

    public void OnInitializationComplete()
    {
        
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.LogError($"Error {message} :: {error.ToString()}");
    }
}