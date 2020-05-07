using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject focus;                            // the GameObject is the car
    public float distance = 5f;                          //float to control the camera follow distance
    public float voffset = 2f;                          // this will control the verticle offset applied to the camera.
    public float dampening = 1f;                        //this is a value to dampen the movemnet of the camera.

   

    // Update is called once per frame
    void FixedUpdate()                                  // the camera will be following the player so FixedUpdate will be better than Update
    {
        transform.position = Vector3.Lerp(transform.position, focus.transform.position + focus.transform.TransformDirection (new Vector3(0f, voffset, -distance))* dampening ,Time.deltaTime);
        transform.LookAt(focus.transform);
    }// so this one is a bitch
    //tranform.position of the camera = Vector3.Lerp is a vector3 that will interpolates between 2 points.(position of the camera, position of the car + the TransformDirection of the car)
}
