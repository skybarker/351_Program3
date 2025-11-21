using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GameObject bullet;
    public AudioSource Gunshot;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) { Fire(bullet); }

    }

    public void Fire(GameObject prefab)
    {
        GameObject bulletClone = Instantiate(prefab, transform.position, transform.rotation);
        Gunshot.Play();    

        

    }

}
