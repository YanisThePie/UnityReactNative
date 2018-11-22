using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSprite : MonoBehaviour {

    float timer = 0;
    public float thrust = 1;
    Rigidbody RB;
    Transform bT;
    Vector3 forward;

	// Use this for initialization
	void Start () {
        RB = this.GetComponent<Rigidbody>();
        bT = this.GetComponent<Transform>();

        forward = bT.forward;

    }
	
	// Update is called once per frame
	void Update () {
		if(timer >= 10)
        {
            Destroy(gameObject);
        }
        else
        {
            timer += Time.deltaTime;
        }

        RB.AddForce(forward * thrust);

        bT.localEulerAngles += new Vector3(0, 0, 1);

	}
}
