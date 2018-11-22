using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawMobScript : MonoBehaviour {
    float timer = 0;
    public List<GameObject> ListMob = new List<GameObject>();
    public float frequence;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (timer >= frequence)
        {
            timer = 0;
            frequence = Random.Range(0, 6);
            ListMob[Random.Range(0, ListMob.Count)].GetComponent<targetScript>().Activate();

        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
