using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetScript : MonoBehaviour {
    Vector3 origin;
    public bool start = false;
    float state = 0;
    public int speed;

	// Use this for initialization
	void Start () {
        origin = GetComponent<Transform>().localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        if (start)
        {

            state += (float)speed / 1000;

            GetComponent<Transform>().localPosition = Vector3.Lerp(origin, Camera.main.GetComponent<Transform>().localPosition, state);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        Camera.main.GetComponent<GameScript>().AddScore();
        gameObject.SetActive(false);
        GetComponent<Transform>().localPosition = origin;
        start = false;
    }

    public void Activate()
    {
        start = true;
        gameObject.SetActive(true);
    } 
}
