using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sounds
{    
    /// <summary>
    // This script handles the properties of the Sound Manager script //
    /// </summary>

    public string name;         // Reference to the audio name
    public AudioClip clip;      // Reference to the audio clip

    [Range(0f, 1f)]
    public float volume = 0.5f; // Reference slider for the volume. 

    public bool loop;           // Reference for looping audio

    [HideInInspector]
    public AudioSource source;  // Reference to the audio source
}
