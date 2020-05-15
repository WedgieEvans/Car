using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{

    public float damage;// this is just the current MPH of the car * damageModifier
    
    public Rigidbody rb;
    public float damageModifier = 2f;// this will multiply the damage


     void Update()
    {
        damage = transform.InverseTransformVector(rb.velocity).z * 2.23694f * damageModifier; // this makes damage into the current MPH of the player * damageModifier.
    
    }
    void OnTriggerEnter(Collider hitInfo)// void OnTriggerEnter will activate when two colliders intersect. 
    {
        AnimalLife animalLife = hitInfo.GetComponent<AnimalLife>();//AnimalLife is a class i then name animalLife as a local variable. i set it equal to the component's AnimalLife script
        if (animalLife != null)//if not equal to null. (if i collide with something that has the AnimalLife script)
        {
            animalLife.TakeDamage(damage);//activate the TakeDamage in the AnimalLife script. giving the parameter the damage variable
            Debug.Log("SMASH");//add sound effects
            
        }
    }
}
