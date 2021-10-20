using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;
    public bool isMusicEnabled;
    public bool isSoundEnabled;

    [HideInInspector] public string musidId;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        ChangeMusicVolume("music_1");
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found!");
            return;
        }

        if (isSoundEnabled)
        {
            s.source.Play();
        }
        
    }

    public void ChangeMusicVolume(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Music: " + name + " not found!");
            return;
        }

        if (isMusicEnabled)
        {
            s.source.volume = 0.01f;
        }
        else s.source.volume = 0;

        s.source.Play();

    }



}
