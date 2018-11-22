using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameScript : MonoBehaviour {
    public int score;
    public GameObject scoretxt, timetxt;
    public float timer;
    public float duration;

	// Use this for initialization
	void Start () {
        score = 0;
        timetxt.GetComponent<Text>().text = "Time Left : " + duration;
    }
	
	// Update is called once per frame
	void Update () {
        if (timer >= 1)
        {
            timer = 0;
            duration--;
            timetxt.GetComponent<Text>().text = "Time Left : " + duration;
        }
        else
        {
            timer += Time.deltaTime;
        }
       

    }

    public void AddScore()
    {
        score += 100;
        scoretxt.GetComponent<Text>().text = "Score : " + score;
    }
}
