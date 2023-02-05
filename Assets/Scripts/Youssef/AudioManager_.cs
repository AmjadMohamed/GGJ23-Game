using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_ : MonoBehaviour
{
    public static AudioManager_ instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    //if i wanna add some BGmusic with separate source and function to control it
    public void playMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("sound not found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }

    }
    public void playSFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("sfx not found");
        }
        else
        {
            sfxSource.clip = s.clip;
            if (!sfxSource.isPlaying)
                sfxSource.Play();
        }

    }
    public void stopSFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("sfx not found");
        }
        else
        {
            sfxSource.clip = s.clip;
                sfxSource.Stop();
        }

    }
    public void loopSFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("sfx not found");
        }
        else
        {
            sfxSource.clip = s.clip;
            sfxSource.loop= true;
        }

    }
}
