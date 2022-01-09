using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    /// <summary>
    // This script handles the sounds of the entire application //
    /// </summary>
 
    public Sounds[] sounds;                                     // Reference to the sound properties stored in Sounds class
    public static SoundManager instance;                        // Setting the instance

    private void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);                                    // Checking that if there any additional instance except this and it will destroyed
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        FindObjectOfType<SoundManager>().Play("Theme");
    }
    public void Play(string name)                                   // Audio play public method
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)                                   // Audio stop public method
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);

        s.source.Stop();
    }
}
