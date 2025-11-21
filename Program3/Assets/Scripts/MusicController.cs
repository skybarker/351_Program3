using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [Tooltip("Music list for active scene view")]
    [SerializeField]
    private MusicTrack[] musicTracks;

    private AudioSource _activeTrack = null;


    // types of music tracks
    public enum MusicType
    {
        None,
        Default,
        Suspense,
        Fight
    }

    // music type key value pair associations
    [Serializable]
    public struct MusicTrack
    { 
        public MusicType   key;
        public AudioSource music;
    }

    // private hash table of key value pairs
    private Hashtable _musicHash;

    // mute toggle for active music track
    private bool _muteMusic = false;

    // the input controller mapping
    //private InputController _inputMap;

    // switch the active music track
    public void SwitchMusic (MusicType id)
    {
        if (_activeTrack != null)
            _activeTrack.Pause();

        // grab the track and play it
        AudioSource track = (AudioSource) _musicHash[id];
        if (track != null)
        {
            // play if music is not muted
            if (!_muteMusic)
                track.Play();

            _activeTrack = track;
        }
    }

    // mute the active music track
    public void ToggleMute()
    {
        _muteMusic = !_muteMusic;
        if (_activeTrack != null)
        {
            if (_muteMusic)
                _activeTrack.Pause();
            else
                _activeTrack.Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {


        
        // get a reference to the input map
        //GameObject gc = GameObject.FindGameObjectWithTag("GameController");
        //_inputMap = gc.GetComponent<InputController>();

        // create and initialize the hashtable for music look-up
        _musicHash = new Hashtable();
        foreach (MusicTrack track in musicTracks)
        {
            _musicHash.Add(track.key, track.music);
        }

        // start music system
        SwitchMusic(MusicType.Default);
    }
        
           
        


   



    // Update is called once per frame
    void Update()
    {
        // toggle mute of the music soundtrack
        //if (_inputMap.GetKeyInput(InputController.ActionType.MusicToggle))
        //{
        //     ToggleMute();
        // }
    } 
}


        // public GameObject supplyStore = GameObject.Find("Supply_Store_Bldg");
 // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         Debug.Log("Player entered the trigger zone!");
    //         Suspense.Play();
    //     }
    // }

     // private void supplyStore.OnTriggerEnter(Collider other)
            //     {
            //         if (other.CompareTag("Player"))
            //         {
            //             Debug.Log("Player entered the trigger zone!");
            //             Suspense.Play();
            //         }
            //     }
        