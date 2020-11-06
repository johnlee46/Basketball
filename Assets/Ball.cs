using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public GameObject ball;
    public GameObject target;
    private GameObject playerCamera;

    private bool holdingBall = true;
    public float force = 2000f;

    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 velocity;
    public float forwardPosition = 15.0f;


    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");

    }

    // Update is called once per frame
    void Update()
    {
        
        if (holdingBall)
        {
            ball.transform.position = playerCamera.transform.position + playerCamera.transform.forward * forwardPosition;
            if (Input.GetMouseButtonDown(0))
            {
                holdingBall = false;
                ball.GetComponent<Rigidbody>().useGravity = true;
                //Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //velocity = new Vector3(touchPosition.x, touchPosition.y, transform.position.z) - transform.position;
                //ball.GetComponent<Rigidbody>().AddForce(velocity * force);
                //ball.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * force);

            }
        }

    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    //when player release the mouse to flick or / touch if mobile
    void OnMouseUp()
    {
        Debug.Log(transform.position);
        Debug.Log(GameObject.FindGameObjectWithTag("target").transform.position);
        var dir = GameObject.FindGameObjectWithTag("target").transform.position - transform.position;
        dir = dir.normalized;
        ball.GetComponent<Rigidbody>().AddForce(dir*force);
    }

}
