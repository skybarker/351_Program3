using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
   [SerializeField]private ParticleSystem explode;
   [SerializeField]private GameObject prefab;
   [SerializeField]private AudioSource Boom;


    private void OnCollisionEnter(Collision other)
    {
        // if (other.gameObject.tag == "Bullet"){
        //     //explode.Play();
        //     //Boom.Play();
        //     //GameObject brokenBarrel = Instantiate(prefab, transform.position, transform.rotation);
        //     //Destroy(gameObject);
        //     }
    }
}
