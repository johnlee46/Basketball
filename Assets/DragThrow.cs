using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragThrow : MonoBehaviour
{

    public GameObject hoop;
    public GameObject ball;
    private GameObject currentBall;
    private Rigidbody rigidbody;
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 oldMouse;
    private Vector3 mouseSpeed;
    public float speed = 5;
    public float time = 0.0f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        //Debug.Log(time.ToString());
        if (time > 5.0f)
        {
            if(currentBall != null)
            {
                Destroy(currentBall);
            }
            time = 0.0f;
            currentBall = Instantiate(ball, ball.transform.position, Quaternion.identity) as GameObject;
        }
    }
    void OnMouseDown()
    {
        oldMouse = Input.mousePosition;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }


    void OnMouseDrag()
    {
        var curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) - offset;
        transform.position = curPosition;

    }

    void OnMouseUp()
    {
        mouseSpeed = (oldMouse - Input.mousePosition);
        //rigidbody.AddForce(mouseSpeed * speed * -1, ForceMode.Force);
        rigidbody.AddTorque(100, 0,0);

    }
}