using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspenseMusic : MonoBehaviour
{    

    private MusicController music;

    // Start is called before the first frame update
    void Start()
    {
    GameObject gc = GameObject.FindGameObjectWithTag("GameController"); 
    music = gc.GetComponent<MusicController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            music.playSuspense();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            music.playDefault();
        }
    }
}
