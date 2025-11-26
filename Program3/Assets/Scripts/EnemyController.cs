using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   public AudioClip taunt1;
   public AudioClip taunt2;
   public AudioClip taunt3;
   public GameObject enemy;
   private AudioClip[] taunts;
   private AudioSource yellTaunt;
   private float tauntTimer = 0;
   private float tauntTrigger;
   public Transform target; 
   public float rotationSpeed = 3f;
   private Vector3 newDirection;
   private Vector3 direction;
   private Animator animController;
   private bool _isAlive = true;
   
   // Start is called before the first frame update
    void Start()
    {
        direction = transform.forward;
        newDirection = transform.forward;
        taunts = new AudioClip[3];
        taunts[0] = taunt1;
        taunts[1] = taunt2;
        taunts[2] = taunt3;
        yellTaunt = enemy.GetComponent<AudioSource>();
        tauntTrigger = Random.Range(10f,30f);
        animController = enemy.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_isAlive){
            tauntTimer += Time.deltaTime;
            if (tauntTimer > tauntTrigger)
            {
                direction = (target.position - transform.position).normalized;
                direction.y = 0f;
                int randomIndex = Random.Range(0, 2);
                yellTaunt.clip = taunts[randomIndex];
                yellTaunt.Play();

                tauntTimer = 0;
                tauntTrigger = Random.Range(10f,30f);
            }
                newDirection = Vector3.RotateTowards(transform.forward, direction, rotationSpeed * Time.deltaTime, 0.0f);
                transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    public void Die()
    {
        animController.SetTrigger("Die");
        _isAlive = false;
    }

}

