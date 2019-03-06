using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kenar : MonoBehaviour//İSMAİL SEFA AKDENİZ
{
    public GameObject[] Kenarlar;
    public Material[] Renk;
    public GameObject Top;
    int sayac = 0;

    void Start()//İSMAİL SEFA AKDENİZ
    {
        Test();
    }

    void Test()
    {
        if (GameObject.FindGameObjectWithTag("Kontrol").GetComponent<BoxKontrol>().durum == 1)
        {
            sayac++;
            for (int i = 0; i < 4; i++)
            {
                Kenarlar[i].GetComponent<Renderer>().material = Renk[sayac % 9];
            }
            Top.GetComponent<Renderer>().material = Renk[sayac % 9];          
        }
        Invoke("Test", 0.1f);
    }
}
