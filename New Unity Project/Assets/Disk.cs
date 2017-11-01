using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk : MonoBehaviour {

    public GameObject MainCamera;
    public GameObject Gula;
    public Rigidbody rb;

	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void Update() {
        if (Camera_script.Walking_mode == false)
        {
            if (Input.GetKey("space"))
            {
                Vector3 v = MainCamera.transform.forward * 15;
                rb.velocity = v;
            }
        }
    }
}
