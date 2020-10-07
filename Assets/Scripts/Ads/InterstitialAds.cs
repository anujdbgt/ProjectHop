using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class InterstitialAds : MonoBehaviour
{
    public static InterstitialAds ads;

    private InterstitialAd interstitial;

#if UNITY_ANDROID
    string adUnitId = "ca-app-pub-4225086287205253/6546613972";  //using Test ID
#else
    string adUnitId = "unexpected_platform";
#endif

    private void Awake()
    {
        ads = this;
    }

    private void Start()
    {
        RequestInterstitial();
    }
    private void RequestInterstitial()
    {
        //Creating Interstitial Ads
        this.interstitial = new InterstitialAd(adUnitId);
        //Loading Ads
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }

    public void ShowAds()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }
}
