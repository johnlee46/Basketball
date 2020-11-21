using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

    // Use this for initialization
    //public GameObject target;
    public float speed = 1.19f;
    Vector3 pointA;
    Vector3 pointB;
    void Start () {
        pointA = new Vector3(-5, 0, 7);
        pointB = new Vector3(5,0 , 7);
    }
	
	// Update is called once per frame
	void Update () {
        GameObject target = GameObject.FindGameObjectWithTag("ball");
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);

    }
}
