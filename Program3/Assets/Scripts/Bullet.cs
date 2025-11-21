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

}
