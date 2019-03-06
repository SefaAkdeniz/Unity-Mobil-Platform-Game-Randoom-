using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenüKontrol : MonoBehaviour//İSMAİL SEFA AKDENİZ
{
    AudioSource Audio;
    
    public void StartGame()//İSMAİL SEFA AKDENİZ
    {      
        PlayerPrefs.SetInt("İzledi", 0);
        Audio = GetComponent<AudioSource>();
        Audio.Play();
        GameObject.FindGameObjectWithTag("reklam").GetComponent<ReklamInterstitial>().ReklamGöster();
        SceneManager.LoadScene("Game");;
    }
    
    public void Exit()
    {
        Audio = GetComponent<AudioSource>();
        Audio.Play();
        Application.Quit();
    }

    public void Custom()
    {
        Audio = GetComponent<AudioSource>();
        Audio.Play();
        SceneManager.LoadScene("Ayarlar");
    }
}
