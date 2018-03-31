using UnityEngine.Audio;
using System; //allows us to use Array. to find the sound
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    public static AudioManager instance;
    // Use this for initialization
	void Awake () {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;

        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
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
       
        //Play("test");
        
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Soubnd: " + name + " not found");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void MuiscOn()
    {
        foreach (Sound s in sounds)
        {
            s.volume = .225f;
            s.source.volume = s.volume;
        }
    }

    public void MusicOff()
    {
        //MenuAudio.Music = 0;
        foreach (Sound s in sounds)
        {
            s.volume = 0f;
            s.source.volume = s.volume;
        }
    }
    
}
