using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalLife : MonoBehaviour
{
    public float health = 100f;
    public GameObject redMist; //hehehehehe
    public float deathTrigger1 = 0f; // these death triggers will control what health the animal has to hit to trigger different deaths.
    public float deathTrigger2 = 50f;// deathTrigger1 will control the redMist(harder hit) and deathTrigger2 will control the lighter hits.
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= deathTrigger1)//checks if health is less than or equal to deathTrigger1.
        {
            Die();//redMist trigger
        }
        else if (health <= deathTrigger2)//else if is key so that multiple death triggers dont occur at the same time for 1 game object.
        {
            Die2();//lighter hit death. Giblets? hehehehe
        }
    }
    void Die()
    {
       GameObject mistGO = Instantiate(redMist, transform.position, transform.rotation);//this instantiates the redMist particle effect. i also set it as a local varible calling it MistGO. thats for Mist Game Object
        Destroy(mistGO,2f);//i use the local variable i created to destroy it after 2f (seconds?)
        Destroy(gameObject);// this destroys the animal game object
      
    }
    void Die2()// this will be the second death animation. 
    {
        Destroy(gameObject);
        Debug.Log("Death 2");
    }
    
}
