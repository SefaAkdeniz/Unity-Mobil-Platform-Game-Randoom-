using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunSonuKontrol : MonoBehaviour//İSMAİL SEFA AKDENİZ
{
    public Text Skorun;
    public Text High;
    public float Skor ;
    public static float best ;
    AudioSource Audio;

    void Start()//İSMAİL SEFA AKDENİZ
    {
        Audio = GetComponent<AudioSource>();
        
        Skor = PlayerPrefs.GetFloat("Zaman");
        Skor += PlayerPrefs.GetInt("ToplananAltin")*10;
        Skorun.text = "SCORE: " + Skor.ToString("0");
        best = PlayerPrefs.GetFloat("best");
        if (Skor >= best)
        {
            best = Skor;
            PlayerPrefs.SetFloat("best", best);
        }
        High.text = "HİGHEST SCORE: " + best.ToString("0");
    }

    public void Restart()
    {
        Audio.Play();
        GameObject.FindGameObjectWithTag("reklam2").GetComponent<ReklamInterstitial>().ReklamGöster();
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Audio.Play();
        Application.Quit();
    }

    public void Setting()
    {
        Audio.Play();
        SceneManager.LoadScene("Ayarlar");
    }
}
