using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]        //this tells the script that the InputManager script i made is required for this script to run
[RequireComponent(typeof(Rigidbody))]           // this tells rigidbody is required is this script
public class CarController : MonoBehaviour
{
    public InputManager input;                        // i make a variable for my InputManager script and name it input.
    public List<WheelCollider> throttleWheels;        //a List contains multiple <WheelCollider> in one variale. i then name it throttleWheels as this will control the cars forward speed. the list will have all 4 of my wheel colliders in it
    public List<GameObject> steerWheels;              //this List will contain <GameObject> naming this variable steerWheels. this list will have 2 items. the 2 game objects are empty objects. the wheel meshes are parented to the empty objects. Empty objects i created have uniform transforms and there for be easier to control.
    public List<GameObject> meshes;                   // this list contain my wheel meshs in a list of 4. i name the list variable meshes
    public float strengthCoefficient = 20000f;        //this float is essentially how fast the car can go
    public float maxSteer = 30f;                      //this will contain the angle that the 2 front wheels rotate left or right. 
    public Transform CM;                              //this makes the transform of the car into a variable called  CM. This will be a empty object placed on the car that will be center of mass.
    public Rigidbody rb;                              //Rigidbody of the car will be called rb
    

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<InputManager>();      //i believe this is to make sure the input variable is the InputManager script.
        rb = GetComponent<Rigidbody>();            //this makes sure rb is the car Rigidbody.
            if (CM)                                
            {
                rb.centerOfMass = CM.localPosition;//rb.centerOfMass is the cars center of mass by default = CM.localPosition. this is the local position of the empty object.
            }
            
    }

    // Update is called once per frame
    void FixedUpdate()          //Fixed Updates are better for physics 
    {
        foreach (WheelCollider wheel in throttleWheels)                                                                                                 // foreach will apply script commands to each item in the list. the arguments tells it to find the WheelCollider(i named it "wheel" as a local variable that i can change) in the throttleWheels List.
        {
            wheel.motorTorque = strengthCoefficient * Time.deltaTime * (input.throttle * input.turbo);                                                  //this sets the motorTorque of all 4 wheels to the strengthCoefficient of the car. * (input.throttle * input.turbo) input.throttle can only be 0 if "W" or "S" is NOT pressed. "W" will be 1 and "S" will be negative 1. input.turbo will only be 1 or the turboMultiplier float found in the InputManager script.
        }    //motorTorque is  command that applys torque to the wheels. a positive number will be forward and negative will be back.
        foreach (GameObject wheel in steerWheels)                                                                                                       //the objects in this list will be the empty objects the wheel meshes are parented to the local variable will be called "wheel"
        {
            wheel.GetComponent<WheelCollider>().steerAngle = maxSteer * input.steer;                                                                    //.steerAngle sets the steering angle in degrees only on the Y axis. = to maxSteer float * input.steer 
            wheel.transform.localEulerAngles = new Vector3(0f, input.steer * maxSteer, 0f);                                                             //the Vector3 will only change on the y for rotation. it gets values from input of "A" and "D" * the maxSteer float.
       }  //transform.localEulerAngles  will change the rotation relative to the parent 

        foreach (GameObject mesh in meshes)                                                                                                             // the meshes in this list is actually the empty objects that are parents to the wheel meshes
        {
            mesh.transform.Rotate(0f,0f, rb.velocity.magnitude + (transform.InverseTransformDirection(rb.velocity).z *.5f) * (2f + Mathf.PI + 0.15f)) ; // this code sets the mesh.transform.Rotate of the wheel mesh on the z axis. this will make the wheels look like they are rolling.
                                                                                                                                                        // velocity of the car + (world space of the velocity converted into local space).z    .z gets only the z value * .5f * the wheels circumfrence. i have the .5f to slow down the wheel spinning. it didnt look right originally
        }
       
    }
}
