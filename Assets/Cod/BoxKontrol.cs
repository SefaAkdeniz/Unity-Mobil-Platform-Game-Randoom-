using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxKontrol : MonoBehaviour//İSMAİL SEFA AKDENİZ
{
    public GameObject[] Box;
    public GameObject[] Kenar;
    public GameObject[] Altinlar;
    public Material[] Renk;
    public GameObject Top;
    AudioSource Audio;
    int Rast;
    int RastAltin;
    public int durum=1;
    
    void Start()//İSMAİL SEFA AKDENİZ
    {
        Audio = GetComponent<AudioSource>();
        Audio.volume = (PlayerPrefs.GetFloat("Ses") / 100);
        Invoke("RenkBelirle", 3f);
    }

    void RenkBelirle()
    {   
        Rast = Random.Range(0, 8);     
        Audio.Play();
        durum = 0;
        for (int i = 0; i < 4; i++)
        {
            Kenar[i].GetComponent<Renderer>().material = Renk[Rast];
        }
        

        Top.GetComponent<Renderer>().material = Renk[Rast];

        int Step2 = Random.Range(1, 10);
        if (Step2 <= 3)
        {
            Invoke("RenkBelirle", 1.5f);
        }
        else
        {                                    
            Invoke("KutuKapat", 3.5f);
        }       
    }

    void KutuKapat()
    {
        Altinlar[RastAltin].SetActive(false);
        for (int i = 0; i < 9; i++)
        {
            if (i == Rast)
            {
                continue;
            }
            else
            {
                Box[i].SetActive(false);
            }
        }
        Invoke("KutuAc", 1f);
    }

    void KutuAc()
    {
        if (GameObject.FindGameObjectWithTag("Top").GetComponent<TopKontrol>().kontrol == 0)
        {
            durum = 1;         

            for (int i = 0; i < 9; i++)
            {
                Box[i].SetActive(true);
            }
            int AltinSans = Random.Range(1, 10);
            if (AltinSans <= 3)
            {
                RastAltin = Random.Range(0, 8);
                Altinlar[RastAltin].SetActive(true);
            }
            Invoke("RenkBelirle", 2f);
        }
    }
}
