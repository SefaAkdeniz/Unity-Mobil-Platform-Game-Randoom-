using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Reklam : MonoBehaviour
{
    
    void Start()
    {
        MobileAds.Initialize("ca-app-pub-5629669455408755~1285659140");

        BannerView reklamObjesi = new BannerView("ca-app-pub-5629669455408755/6290875135", AdSize.SmartBanner, AdPosition.Top);
        AdRequest reklamIstegi = new AdRequest.Builder().Build();
        reklamObjesi.LoadAd(reklamIstegi);
        reklamObjesi.Show();

    }

    



}
