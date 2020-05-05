using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class CarController : MonoBehaviour
{
    public InputManager input;
    public List<WheelCollider> throttleWheels;
    public List<WheelCollider> steerWheels;
    public float strengthCoefficient = 20000f;
    public float maxSteer = 20f;
    

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<InputManager>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (WheelCollider wheel in throttleWheels)
        {
            wheel.motorTorque = strengthCoefficient * Time.deltaTime * (input.throttle + input.turbo);
        }
        foreach (WheelCollider wheel in steerWheels)
        {
            wheel.steerAngle = maxSteer * input.steer;
        }
    }
}
