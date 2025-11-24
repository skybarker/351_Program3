using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GameObject bullet;
    public AudioSource Gunshot;
    public float shotCD = 1;
    private float shotTimer = 1;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shotTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.F)) 
        { 

            if (shotTimer>shotCD) 
            {
                Fire(bullet);
                shotTimer = 0;
            }
  
        }

    }

    public void Fire(GameObject prefab)
    {
        GameObject bulletClone = Instantiate(prefab, transform.position, transform.rotation);
        Gunshot.Play();    

        

    }

}
