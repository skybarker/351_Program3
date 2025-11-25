using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GameObject bullet;
    public AudioSource Gunshot;
    public float shotCD = 1;
    private float shotTimer = 1;
    private MusicController music;

    
    // Start is called before the first frame update
    void Start()
    {
    GameObject gc = GameObject.FindGameObjectWithTag("GameController"); 
    music = gc.GetComponent<MusicController>();
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
                //music.SwitchMusic(MusicType.Fight);
            }
  
        }

    }

    public void Fire(GameObject prefab)
    {
        GameObject bulletClone = Instantiate(prefab, transform.position, transform.rotation);
        Gunshot.Play();    

        

    }

}
