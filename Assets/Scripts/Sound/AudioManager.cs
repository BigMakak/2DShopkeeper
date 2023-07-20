using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    // THIS code was imported from another project
    // Using this just to play sounds
    public static AudioManager instance;

    public AudioMixerGroup MainMixer;

    public Sound[] Sounds;


    private void Awake()
    {

        //Singleton Pattern for the AudioManager
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        SetupAudio();
    }

    void Start()
    {
        PlayAudio("MainTheme");
    }


    public void PlayAudio(string name)
    {
        Sound sound = Array.Find(this.Sounds, sound => sound.Name == name);

        if (sound == null)
        {
            Debug.LogWarning("Sound with name: " + name + " was not found");
            return;
        }

        sound.source.Play();

        return;
    }

    private void SetupAudio()
    {
        foreach (Sound s in Sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.Loop;
            s.source.outputAudioMixerGroup = MainMixer;

            s.source.pitch = s.pitch;
        }
    }


    public bool CheckIsPlaying(string name)
    {

        Sound sound = Array.Find(this.Sounds, sound => sound.Name == name);

        if (sound == null)
        {
            Debug.LogWarning("Sound with name: " + name + " was not found");
            return false;
        }

        return sound.source.isPlaying;
    }
}
