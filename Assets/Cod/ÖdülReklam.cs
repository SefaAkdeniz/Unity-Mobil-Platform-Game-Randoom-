using UnityEngine;
using System;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class ÖdülReklam : MonoBehaviour
{
    void Start()
    {
        
        MobileAds.Initialize("ca-app-pub-5629669455408755~1285659140");
        YeniReklamAl(null, null);   
        RewardBasedVideoAd reklamObjesi = RewardBasedVideoAd.Instance;
        reklamObjesi.OnAdClosed -= YeniReklamAl;
        reklamObjesi.OnAdClosed += YeniReklamAl; // Kullanıcı reklamı kapattıktan sonra çağrılır
        reklamObjesi.OnAdRewarded -= OyuncuyuOdullendir;
        reklamObjesi.OnAdRewarded += OyuncuyuOdullendir; // Kullanıcı reklamı tamamen izledikten sonra çağrılır
    }

    void OnGUI()
    {   
        // Butonu sadece reklam tamamen yüklenmişse (IsLoaded() true ise) tıklanabilir yap
        GUI.enabled = RewardBasedVideoAd.Instance.IsLoaded();

       
        
            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 75, 400, 100), "Kaldığın Yerden Devam Et"))
            {
                RewardBasedVideoAd.Instance.Show();
            }
        

        GUI.enabled = true;
    }

    public void YeniReklamAl(object sender, EventArgs args)
    {
        RewardBasedVideoAd reklamObjesi = RewardBasedVideoAd.Instance;

        AdRequest reklamIstegi = new AdRequest.Builder().Build();
        reklamObjesi.LoadAd(reklamIstegi, "ca-app-pub-5629669455408755/5749935181");
    }

    private void OyuncuyuOdullendir(object sender, Reward odul)
    {
        PlayerPrefs.SetInt("İzledi", 1);
        SceneManager.LoadScene("Game");
    }
}