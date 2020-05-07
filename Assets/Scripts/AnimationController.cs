using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class AnimationController : MonoBehaviour
{ 
    public InputManager input;
    public ParticleSystem flames;
    public GameObject flameSpawn;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      //  if (Input.GetKey(KeyCode.Space))
      //  {
          //  Debug.Log("Space was presed");
          //  jet();
      //  }
    }
    void jet()
    {
        Instantiate(flames, flameSpawn.transform.position, Quaternion.identity);
        
    }
}

