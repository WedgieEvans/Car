using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public float throttle;
    public float steer;
    public float turbo = 0f;
    public float turboValue = 5000;
    // Update is called once per frame
    void Update()
    {
        throttle = Input.GetAxis("Vertical");
        steer = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.E))
        {
            turbo = turboValue;
        }
        else
        {
            turbo = 0;
        }
      



    }
}

