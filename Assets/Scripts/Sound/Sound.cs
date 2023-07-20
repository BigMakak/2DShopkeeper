using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
     // THIS code was imported from another project
    // Using this just to play sounds
    
    public string Name;
    public AudioClip clip;

    [Range(0f,1f)]
    public float volume = 1;
    [Range(0.1f,3f)]
    public float pitch = 1;

    [HideInInspector]
    public AudioSource source;

    public bool Loop;
}