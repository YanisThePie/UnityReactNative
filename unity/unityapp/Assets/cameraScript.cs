using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraScript : MonoBehaviour {

    public GameObject bulletPrefab;
    Transform cT;
    public GameObject gyroTxtSpot;
    Text gyroTxt;

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
        transform.rotation = GyroToUnity(Input.gyro.attitude);
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
}
