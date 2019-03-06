using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ayarlar : MonoBehaviour//İSMAİL SEFA AKDENİZ
{
    public Text Sound;
    public Text Speed;
    public GameObject Sescubuk;
    public GameObject Hizcubuk;
    Slider Ses;
    Slider Hiz; 

    void Start()//İSMAİL SEFA AKDENİZ
    {
        Ses = Sescubuk.GetComponent<Slider>();
        Ses.value = PlayerPrefs.GetFloat("Ses");
        Hiz = Hizcubuk.GetComponent<Slider>();
        Hiz.value = PlayerPrefs.GetFloat("Hiz");            
    }
    
    public void Back()
    {             
        SceneManager.LoadScene("AnaMenü");
    }

    public void Hizlamma()
    {
        Speed.text = "Ball Speed: " + PlayerPrefs.GetFloat("Hiz").ToString();         
        PlayerPrefs.SetFloat("Hiz", Hiz.value);
    }

    public void Sesleme()
    {
        Sound.text = "Sound: " + PlayerPrefs.GetFloat("Ses").ToString("0");      
        PlayerPrefs.SetFloat("Ses", Ses.value);
    }
}
