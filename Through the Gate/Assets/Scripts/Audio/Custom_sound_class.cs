using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Custom_sound_class 
{
    public string name;

    [Range(0f,1f)]
    public float volume;

    [Range(0f, 3f)]
    public float pitch;

    public AudioClip clip;
    public AudioSource audio_source; 
}
