using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 3f;
    public float thrust = 1.0f;
    public Rigidbody rb;
    //private AudioClip death;    
   // private AudioSource Enemy_shot;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(0, 0, thrust, ForceMode.Impulse);
        Destroy(gameObject, lifetime);


    }   

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            // Destroy the enemy
            //Enemy_shot = col.gameObject.GetComponent<AudioSource>();
            //Enemy_shot.Play();
            Animator animController = col.gameObject.GetComponent<Animator> ();
            animController.SetTrigger("Die");
            //Destroy(col.gameObject);
               

            // Destroy the bullet
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("Explosive"))
        {
            // Destroy the enemy
            //Destroy(col.gameObject);

            // Destroy the bullet
            //Destroy(gameObject);
        }

    }

}
