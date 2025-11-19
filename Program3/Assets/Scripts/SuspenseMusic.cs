using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspenseMusic : MonoBehaviour
{
    public AudioSource suspenseMusic;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone!");
            suspenseMusic.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
