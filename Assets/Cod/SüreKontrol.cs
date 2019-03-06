using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SüreKontrol : MonoBehaviour//İSMAİL SEFA AKDENİZ
{
    public float Zaman;
    public Text Süre;
    public Text Paused;
    AudioSource Audio;

    void Start()//İSMAİL SEFA AKDENİZ
    {
        
        if (PlayerPrefs.GetInt("İzledi") == 1)
        {
            Zaman = PlayerPrefs.GetFloat("Zaman");
        }
        Süre.text = Zaman.ToString("0");
        Audio =GetComponent<AudioSource>();
        Audio.volume = (PlayerPrefs.GetFloat("Ses") / 100);
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Top").GetComponent<TopKontrol>().kontrol == 0)
        {
            Zaman += Time.deltaTime;
            PlayerPrefs.SetFloat("Zaman", Zaman);
            Süre.text = Zaman.ToString("0");
        }       
    }

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Audio.volume = 0;
            Time.timeScale = 0;
            Paused.text = "PAUSED";
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            Audio.volume = (PlayerPrefs.GetFloat("Ses") / 100);
            Paused.text = "";
        }
    }
}
