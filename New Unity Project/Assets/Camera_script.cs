using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_script : MonoBehaviour {

    //public GameObject Cap;
    public GameObject Gula;
    public GameObject Disk;
    static public bool Walking_mode = true;
    public bool Backend = true;
    public int force = 0;
    public enum inclination {rotx = 0 , rotz = 0};
    Vector3 zap_pos;
    Quaternion zap_rot;


    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 0F;
    public float sensitivityY = 0F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationY = 0F;


    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (Walking_mode)
        {
            transform.position = new Vector3(Gula.transform.position.x, Gula.transform.position.y + 0.5f, Gula.transform.position.z);

            if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return))
            {
                Gula.transform.position = new Vector3(Disk.transform.position.x, Disk.transform.position.y + 1.5f ,Disk.transform.position.z);
                transform.position = new Vector3(Gula.transform.position.x, Gula.transform.position.y + 0.5f, Gula.transform.position.z);
                //Disk.transform.position = transform.position + (transform.forward * 0.8f);
                if (Backend)
                {
                    Disk.transform.position = transform.position + ((-transform.right - transform.right + transform.forward) * 0.3f);
                }
                else
                {
                    Disk.transform.position = transform.position + ((transform.forward + transform.forward + transform.right) * 0.15f);
                }
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
                Disk.transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

                zap_pos = Disk.transform.position;
                zap_rot = Disk.transform.rotation;
                Walking_mode = false;
            }

            else if (axes == RotationAxes.MouseXAndY)
            {
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            }
            else if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
            }
            else
            {
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
            }
        }

        else /// Disk mode
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //Vector3 rot = (-transform.right*20);
                //Vector3 rot = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("vertical"));
                //Disk.transform.Rotate(Vector3.right, Space.Self);
                //Disk.transform.RotateAround(Disk.transform.position, rot, 45.0f);
                //Disk.transform.Rotate(rot);
            }

            if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
            {
                Backend = !(Backend);
                Debug.Log("Backend = "+ Backend);
                if (Backend)
                {
                    Disk.transform.position = transform.position + ((-transform.right - transform.right + transform.forward) * 0.3f);
                }
                else
                {
                    Disk.transform.position = transform.position + ((transform.forward + transform.forward + transform.right) * 0.15f);
                }
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
                Disk.transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

                zap_pos = Disk.transform.position;
                zap_rot = Disk.transform.rotation;

            }

            if (Input.GetMouseButton(0))
            {
                if (axes == RotationAxes.MouseXAndY)
                {
                    float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

                    rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                    rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                    transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
                    Disk.transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
                }
                else if (axes == RotationAxes.MouseX)
                {
                    transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
                    Disk.transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);

                }
                else
                {
                    rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                    rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                    transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
                    Disk.transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
                }

                if (Backend)
                {
                    Disk.transform.position = transform.position + ((-transform.right - transform.right + transform.forward) * 0.3f);
                }
                else
                {
                    Disk.transform.position = transform.position + ((transform.forward + transform.forward + transform.right) * 0.15f);
                }

                zap_pos = Disk.transform.position;
                zap_rot = Disk.transform.rotation;
            }
            else
            {
                Disk.transform.rotation = zap_rot;
                Disk.transform.position = zap_pos;
            }           
        }       
    }
}
