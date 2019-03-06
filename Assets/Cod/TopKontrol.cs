using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TopKontrol : MonoBehaviour//İSMAİL SEFA AKDENİZ
{
    Rigidbody Fizik;
    public Joystick JoystickCubuk;
    public Text Altın;
    int ToplananAltin;
    AudioSource Ses;
    public int kontrol;
    

    void Start()//İSMAİL SEFA AKDENİZ
    {
        Ses = GetComponent<AudioSource>();
        Ses.volume = (PlayerPrefs.GetFloat("Ses") / 100);
        if(PlayerPrefs.GetInt("İzledi")==1)
        {
            ToplananAltin = PlayerPrefs.GetInt("ToplananAltin");
        }
        Altın.text = ToplananAltin.ToString();
        PlayerPrefs.SetInt("ToplananAltin", 0);
        Fizik = GetComponent<Rigidbody>();      
        kontrol = 0;

        if (PlayerPrefs.GetFloat("Hiz") == 0)
        {
            PlayerPrefs.SetFloat("Hiz", 60f);
        }
        if (PlayerPrefs.GetFloat("Ses") == 0)
        {
            PlayerPrefs.SetFloat("Ses", 60f);
        }
        

    }
    
    void FixedUpdate()
    {
        float Yatay = JoystickCubuk.Horizontal;
        float Dikey = JoystickCubuk.Vertical;

        if (Yatay >= 0.2f)
        {
            Yatay =1f;
        }
        else if(Yatay <= -0.2f)
        {
            Yatay = -1f;
        }
      
        Debug.Log(Yatay);
        if (Dikey >= 0.2f)
        {
            Dikey = 1;
        }
        else if (Dikey <= -0.2f)
        {
            Dikey =-1f;
        }
        
        //if(Dikey==0 || Yatay == 0)
        //{
        //    Fizik.AddForce(0 ,- 10, 0);
        //    Debug.Log("Down");
        //}

        Fizik.AddForce(Yatay * PlayerPrefs.GetFloat("Hiz") / 10, 0, Dikey * PlayerPrefs.GetFloat("Hiz") / 10);
        
    }

    private void Update()
    {
        if (transform.position.y < -1)
        {
            if (kontrol == 0)
            {
                kontrol++;
                GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Pause();
                Ses.Play();
                Invoke("Finish", 3f);
            }
        }
    }

    void Finish()
    {
        PlayerPrefs.SetInt("İzledi", 0);     
        SceneManager.LoadScene("OyunSonu");
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag("Gold").GetComponent<AudioSource>().Play();
        ToplananAltin++;
        PlayerPrefs.SetInt("ToplananAltin", ToplananAltin);
        Altın.text = ToplananAltin.ToString();
        other.gameObject.SetActive(false);
    }
}
