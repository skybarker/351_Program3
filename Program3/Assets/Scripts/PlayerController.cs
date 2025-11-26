using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables; 
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    public float impulseForce  = 170000.0f;
    public float impulseTorque = 3000.0f;

    public GameObject hero;
    public PlayableDirector director;
    public GameObject orbitCam;
    public GameObject firstPersonCam;
    Animator animController;
    Rigidbody rigidBody;
    GameObject currentCam;

    // Start is called before the first frame update
    void Start()
    {
        // get references to the animation controller of hero
        // character and player's corresponding rigid body
        animController = hero.GetComponent<Animator> ();
        rigidBody      = GetComponent<Rigidbody>();
        currentCam = orbitCam;

    }

    // Update is called once per frame
    void Update()
    {
        // W/A/S/D input as a combined rotation and movement vector
        Vector3 input = new Vector3(0, Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    
        // allow movement when input detected and not crouching
        if (input.magnitude > 0.001 && !animController.GetBool ("Crouch"))
        {
            // rotations are about y axis
            rigidBody.AddRelativeTorque(new Vector3(0, input.y * impulseTorque * Time.deltaTime, 0));
            // motion is forward/backward (about z axis)
            rigidBody.AddRelativeForce(new Vector3(0, 0, input.z * impulseForce * Time.deltaTime));
            animController.SetBool("Walk", true);
        }
        else
        {
            animController.SetBool("Walk", false);
            // crouching with 'C' key (only when not moving)
            if (Input.GetKey(KeyCode.C))
                animController.SetBool("Crouch", true);
            else
                animController.SetBool("Crouch", false);
        }

        //Kick
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animController.SetTrigger("Kick");
            animController.SetInteger("KickID", Random.Range(0, 99));
        }

        //Skip cut scene
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            director.Stop();
        }

        //Toggle Camera
        if (Input.GetKeyDown(KeyCode.T))
        {
           if(currentCam == orbitCam)
           {
                firstPersonCam.SetActive(true);
                orbitCam.SetActive(false);
                currentCam = firstPersonCam;
           }
           else
           {
                orbitCam.SetActive(true);
                firstPersonCam.SetActive(false); 
                currentCam = orbitCam; 
           }
        }


    }
}
