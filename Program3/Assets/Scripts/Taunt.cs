using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taunt : MonoBehaviour
{
   
   private AudioSource YellTaunt;
   private float tauntTimer = 0;
   private float tauntTrigger;
   
   // Start is called before the first frame update
    void Start()
    {
        GameObject gc = gameObject;
        YellTaunt = gc.GetComponent<AudioSource>();
        tauntTrigger = Random.Range(10f,30f);
    }

    // Update is called once per frame
    void Update()
    {
        tauntTimer += Time.deltaTime;
        if (tauntTimer > tauntTrigger)
        {
            YellTaunt.Play();
            Debug.Log("A taunt was yelled");

            tauntTimer = 0;
            tauntTrigger = Random.Range(10f,30f);

        }

    }
}
