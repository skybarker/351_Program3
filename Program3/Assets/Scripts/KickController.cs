using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickController : MonoBehaviour
{
    public GameObject player;
    public float kickStrength = 1000.0f;
    private Rigidbody targetRB;
    private Vector3 kickVector;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

    }
void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Kickable") || col.gameObject.CompareTag("Explosive"))
        {
            kickVector = ((player.transform.forward).normalized)*kickStrength + new Vector3(0,200,0);
            Debug.Log("Kickable collision");
            targetRB = col.gameObject.GetComponent<Rigidbody>();
            Debug.Log("Kickable collision with: " + col.gameObject.name);
            targetRB.AddRelativeForce(kickVector, ForceMode.Impulse);
            
               

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
