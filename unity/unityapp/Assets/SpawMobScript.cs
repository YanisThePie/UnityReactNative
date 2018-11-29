using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class SpawMobScript : MonoBehaviour {
    float timer = 0;
    public List<GameObject> ListMob = new List<GameObject>();
    public List<Texture2D> ListImg = new List<Texture2D>();
    public float frequence;
    public Texture2D prevTex, newTex;
    public Texture2D defaultText;
    public GameObject debugTxt;


   /* void Awake()
    {
        UnityMessageManager.Instance.OnRNMessage += onMessage;
    }

    void onDestroy()
    {
        UnityMessageManager.Instance.OnRNMessage -= onMessage;
    }*/


    // Use this for initialization
    void Start () {
        UnityMessageManager.Instance.SendMessageToRN("Tes qu'une pute");
    }
	
	// Update is called once per frame
	void Update () {

       
        if (timer >= frequence)
        {
            timer = 0;
            frequence =  UnityEngine.Random.Range(0, 6);

            if(ListImg.Count <= 0)
            ListMob[UnityEngine.Random.Range(0, ListMob.Count-1)].GetComponent<targetScript>().Activate(defaultText);
            else
            ListMob[UnityEngine.Random.Range(0, ListMob.Count)].GetComponent<targetScript>().Activate(ListImg[UnityEngine.Random.Range(0, ListImg.Count-1)]);



        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    void handleMessage(string message)
    {
        UnityMessageManager.Instance.SendMessageToRN("onMessage:" + message);
        printImage(message);
    }

    /*  void onMessage(MessageHandler message)
      {
          var data = message.getData<string>();
          Debug.Log("onMessage:" + data);
          printImage(data);
          message.send(new { CallbackTest = "I am Unity callback" });
      }*/

    void printImage(String iconBase64String)
    {
       // string iconBase64String = "OBFZDTcPCxlCKhdXCQ0kMQhKPh9uIgYIAQxALBtZAwUeOzcdcUEeW0dMO1kbPElWCV1ISFFKZ0kdWFlLAURPZhEFQVseXVtPOUUICVhMAzcfZ14AVEdIVVgfAUIBWVpOUlAeaUVMXFlKIy9rGUN0VF08Oz1POxFfTCcVFw1LMQNbBQYWAQ==";
        /*byte[] decodedBytes = System.Text.Encoding.UTF8.GetBytes(iconBase64String);
        Texture2D tex = new Texture2D(1, 1);
        tex.LoadImage(decodedBytes);
        ListImg.Add(tex);*/

        Texture2D newPhoto = new Texture2D(1, 1);
        newPhoto.LoadImage(Convert.FromBase64String(iconBase64String));
        newPhoto.Apply();
        ListImg.Add(newPhoto);

        newTex = newPhoto;

        debugTxt.GetComponent<Text>().text = iconBase64String;

    }
}
