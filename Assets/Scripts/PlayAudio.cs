using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{

    public AudioSource intro;
    public AudioSource background_music;

    // Start is called before the first frame update
    void Start()
    {
        background_music.PlayDelayed(1f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
