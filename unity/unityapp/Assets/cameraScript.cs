using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System;

public class cameraScript : MonoBehaviour {

    public GameObject bulletPrefab;
    Transform cT;
    public GameObject gyroTxtSpot;
    Text gyroTxt;

    float oldX = 0, oldY = 0, oldZ = 0;
    /*
    void Awake()
    {
        UnityMessageManager.Instance.OnRNMessage += onMessage;
    }

    void onDestroy()
    {
        UnityMessageManager.Instance.OnRNMessage -= onMessage;
    }
    */
    // Use this for initialization
    void Start () {
        cT = this.GetComponent<Transform>();
        gyroTxt = gyroTxtSpot.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        GyroModifyCamera();
    }

    void GyroModifyCamera()
    {
        cT.rotation = GyroToUnity(Input.gyro.attitude);
        gyroTxt.text = "input.gyro.attitude: " + Input.gyro.attitude;
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

    public void shoot()
    {
        GameObject b = Instantiate(bulletPrefab);
        Transform bT = b.GetComponent<Transform>();
        bT.SetParent(cT);
        bT.localPosition = new Vector3(0, 0, 1);
        bT.eulerAngles = cT.eulerAngles;
    }

    /*void onMessage(MessageHandler message)
    {
        var data = message.getData<string>();
        Debug.Log("onMessage:" + data);
        message.send(new { CallbackTest = "I am Unity callback" });

        if(data.Length <= 10)
        {

        }
    }*/

   public void getGyro(string data)
    {
        UnityMessageManager.Instance.SendMessageToRN("gyro get :" + data);
        
        string[] coord = data.Split(',');
        float x = float.Parse(coord[0]);
        float y = float.Parse(coord[1]);
        float z = float.Parse(coord[2]);

        rotateCam(x,y,z);
    } 

   void rotateCam(float x, float y, float z)
    {
        float newX, newY, newZ;

        //if(oldX > x)
        newX = oldX - x;
        newY = oldY - y;
        newZ = oldX - z;

        oldX = x;
        oldY = y;
        oldZ = z;

        cT.Rotate(newX, newY, newZ);

       
    }

}
