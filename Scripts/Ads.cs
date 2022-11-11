using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds;
using UnityEngine.SceneManagement;
using System;

public class Ads : MonoBehaviour
{
    public static Ads instance;
    private InterstitialAd interstitial;

    bool adshow = false;
    bool start = true;


    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        this.RequestInterstitialAd();
        
    }

    private void Update()
    {
        //if (Coin.instance.finish == true)
        if(start == true)
        {
            if (adshow == false)
            {
                if (this.interstitial.IsLoaded())
                {
                    this.interstitial.Show();
                    adshow = false;
                    start = false; 
                }
            }
        }
        
    }
    public void RequestInterstitialAd()
    {
        string reklamId = "ca-app-pub-3535768035091412/2968943882";

        this.interstitial = new InterstitialAd(reklamId);
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);

        
    }
    public void HandleOnAdClosed(object sender, EventArgs args)
    {
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}