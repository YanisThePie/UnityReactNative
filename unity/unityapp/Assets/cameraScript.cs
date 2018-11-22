using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

    public GameObject bulletPrefab;
    Transform cT;

	// Use this for initialization
	void Start () {
        cT = this.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        GyroModifyCamera();
    }

    void GyroModifyCamera()
    {
        transform.rotation = GyroToUnity(Input.gyro.attitude);
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
