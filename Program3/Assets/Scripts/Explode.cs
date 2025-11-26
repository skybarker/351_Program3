using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
   [SerializeField]private ParticleSystem explode;
   [SerializeField]private GameObject prefab;
   [SerializeField]private AudioSource Boom;

    void Start()
    {
        explode = transform.Find("BigExplosion").GetComponent<ParticleSystem>();    
        Boom = GetComponent<AudioSource>();
        Renderer renderer = GetComponent<Renderer>();   
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet"){
            explode.Play(true);
            Boom.Play();
            GameObject brokenBarrel = Instantiate(prefab, transform.position, transform.rotation);
            GetComponent<Renderer>().enabled = false;
            //Destroy(gameObject);
            }
    }
}
