using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdMobManager : MonoBehaviour
{
    public static AdMobManager instance = null;

    public bool isTestMode;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        LoadFrontAd();
    }

    AdRequest GetAdRequest()
    {
        return new AdRequest.Builder().AddTestDevice("763F7840E1E4838B").Build();
    }

    const string frontTestID = "ca-app-pub-3940256099942544/1033173712";
    const string frontID = "ca-app-pub-1247482884380183/8237508121";
    InterstitialAd frontAd;


    void LoadFrontAd()
    {
        frontAd = new InterstitialAd(isTestMode ? frontTestID : frontID);
        frontAd.LoadAd(GetAdRequest());

    }

    public void ShowFrontAd()
    {
        frontAd.Show();
        LoadFrontAd();
    }



}