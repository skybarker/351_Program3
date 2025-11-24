using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 2f;
    public float thrust = 1.0f;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0, 0, -thrust, ForceMode.Impulse);
        Destroy(gameObject, lifetime);

    }   

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            // Destroy the enemy
            Destroy(col.gameObject);

            // Destroy the bullet
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("Explosive"))
        {
            // Destroy the enemy
            Destroy(col.gameObject);

            // Destroy the bullet
            Destroy(gameObject);
        }

    }

}
