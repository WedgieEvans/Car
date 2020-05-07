using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public float throttle;                        //float to hold car throttle.  This variable is called for in the CarController Script
    public float steer;                         // float to hold how much the front wheels can steer left and right
    public float turbo = 0f;                     //this is the variable that the CarController script reads for. 
    public float turboMultiplier = 2f;           //this is the variable that changes the multiplier when the turbo key is pressed
    public float jump = 0f;
    // Update is called once per frame
    void Update()
    {
        throttle = Input.GetAxis("Vertical");   //Input.GetAxis will only return 1 when "W" is pressed and -1 when "S" is pressed. Then apply it to the throttle float
        steer = Input.GetAxis("Horizontal");    // same thing as the the vertical input except for the the "A" and "D" keys. It applies the values to the steer float.

        if (Input.GetKey(KeyCode.LeftShift))    //This just checks if "LShift" is pressed
        {
            turbo = 1f;            //this changes the turbo float from  a 1 to the turboMultiplier float.
        }           
        else                                     // this makes sure the turbo float is returned back to 1 when the "LShift" is not pressed
        {
            turbo = 0f;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            jump = 1f;
        }

        else
        {
            jump = 0f;
        }


    }
}

