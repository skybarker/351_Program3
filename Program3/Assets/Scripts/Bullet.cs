using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 3f;
    public float thrust = 300.0f;
    public Rigidbody rb;

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
            EnemyController eController = col.gameObject.GetComponent<EnemyController>();
            eController.Die();  

            // Destroy the bullet
            Destroy(gameObject);
        }
    }

}
