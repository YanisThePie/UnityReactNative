using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetScript : MonoBehaviour {
    Vector3 origin;
    public bool start = false;
    float state = 0;
    public int speed;
    Transform tT;

	// Use this for initialization
	void Start () {
        origin = GetComponent<Transform>().localPosition;
        tT = GetComponent<Transform>();
        gameObject.SetActive(false);


    }
	
	// Update is called once per frame
	void Update () {
        if (start)
        {

            state += (float)speed / 1000;

            tT.localPosition = Vector3.Lerp(origin, Camera.main.GetComponent<Transform>().localPosition, state);
            tT.Rotate(new Vector3(1,1,1));

            if (state >= 1)
            {
                GetComponent<Transform>().localPosition = origin;
                start = false;
                gameObject.SetActive(false);
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Camera.main.GetComponent<GameScript>().AddScore();
        state = 0;
        GetComponent<Transform>().localPosition = origin;
        start = false;
        gameObject.SetActive(false);
    }

    public void Activate(Texture2D tex)
    {
    
        start = true;
        gameObject.SetActive(true);
        GetComponent<MeshRenderer>().material.mainTexture = tex;
    } 

 
}
