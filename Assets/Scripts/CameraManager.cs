using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraManager : MonoBehaviour
{

    public GameObject focus;                            // the GameObject is the car
    public InputManager input;
    public float distance = 5f;                          //float to control the camera follow distance
    public float voffset = 2f;                          // this will control the verticle offset applied to the camera.
    public float dampening = 1f;                        //this is a value to dampen the movemnet of the camera.
    public float h2 = 0f;
    public float d2 = 0f;
    public float l2 = 0f;
    private int camMode = 0;

     void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            camMode = (camMode + 1) % 2;
        }
    }
    void FixedUpdate()                                  // the camera will be following the player so FixedUpdate will be better than Update
    {
        switch (camMode)
        {
            case 1:
                transform.position =  focus.transform.position + focus.transform.TransformDirection(new Vector3(l2, h2, d2));
                transform.rotation = focus.transform.rotation;
                break;
             default:
                transform.position = Vector3.Lerp(transform.position, focus.transform.position + focus.transform.TransformDirection(new Vector3(0f, voffset, -distance)) * dampening, Time.deltaTime);
                transform.LookAt(focus.transform);
                break;
        }// so this one is a bitch

    } //tranform.position of the camera = Vector3.Lerp is a vector3 that will interpolates between 2 points.(position of the camera, position of the car + the TransformDirection of the car)
}
