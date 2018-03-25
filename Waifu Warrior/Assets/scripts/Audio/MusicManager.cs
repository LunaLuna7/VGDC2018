using UnityEngine.Audio;
using System;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public Sound[] music;

    public static MusicManager instance;

    void Awake()
    {
        
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;

        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in music)
        {
            //connects the actual audio source to my class Sound
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

    }

    void Start()
    {
    
    }

    public void Play(string name)
    {
        Sound s = Array.Find(music, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Soubnd: " + name + " not found");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(music, sound => sound.name == name);
        s.source.Stop();
    }

    public void MuiscOn()
    {
        foreach (Sound s in music)
        {
            s.volume = .200f;
            s.source.volume = s.volume;
        }
    }

    public void MusicOff()
    {
        //MenuAudio.Music = 0;
        foreach (Sound s in music)
        {
            s.volume = 0f;
            s.source.volume = s.volume;
        }
    }
}
