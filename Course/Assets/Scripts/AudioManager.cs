using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource bgMusic, levelEndmusic;
    public AudioSource[] soundEffects;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSFX(int which)
    {
        soundEffects[which].Stop();
        soundEffects[which].pitch = Random.Range(0.95f, 1.05f);
        soundEffects[which].Play();
    }
}
