using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
   private AudioSource footstepAudio;
   private float minMoveThreshold = 0.1f;
   private Vector3 previousPosition;

   // Start is called before the first frame update
    void Start()
    {
        GameObject gc = gameObject;
        footstepAudio = gc.GetComponent<AudioSource>();
        previousPosition = transform.position;
    }

    void Update()
    {
        float moveDistance = Vector3.Distance(transform.position, previousPosition);
        if(moveDistance >= minMoveThreshold && footstepAudio.isPlaying==false)
        {
            footstepAudio.Play();
            previousPosition = transform.position;
        }
    }

    
}
