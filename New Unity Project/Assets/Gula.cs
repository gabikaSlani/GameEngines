using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gula : MonoBehaviour
{

    public GameObject MainCamera;
    public Rigidbody rb;

    float distance = 20;

    // Use this for initialization
    void Start()
    {
        Physics.gravity = new Vector3(0, -20.0F, 0);
    }

    private void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(MainCamera.transform.forward);

        if (Camera_script.Walking_mode) {
            
            if (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d") || Input.GetKey(KeyCode.LeftArrow)
                || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow))
            {
                if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
                {
                    rb.AddForce(MainCamera.transform.forward * distance);
                }
                if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
                {
                    rb.AddForce(-MainCamera.transform.forward * distance);
                }
                if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
                {

                    rb.AddForce(-MainCamera.transform.right * distance);
                }
                if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
                {
                    rb.AddForce(MainCamera.transform.right * distance);
                }
            }
            else
            {
                rb.velocity = new Vector3(0f, 0f, 0f);
            }
        }
    }
}

