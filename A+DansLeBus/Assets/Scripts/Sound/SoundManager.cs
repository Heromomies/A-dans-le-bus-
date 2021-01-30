using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public Sound.Sound[] sounds;

    public static SoundManager instance;
    private static SoundManager _audioManager => instance;
    private void Awake()
    {
        instance = this;
        foreach (Sound.Sound s in sounds)
        {
            s.audiosource = gameObject.AddComponent<AudioSource>();
            s.audiosource.clip = s.audioclip;
            s.audiosource.volume = s.volume;
            s.audiosource.loop = s.loop;
        }
    }

    public void Start()
    {
        Play("main");
    }

    public void Play(string name)
    {
        Sound.Sound s =  Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarningFormat("Sound " + name + " not found !");
            return;
        }
        s.audiosource.Play();
    }

    public void Stop(string name)
    {
        Sound.Sound s =  Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarningFormat("Sound " + name + " not found !");
            return;
        }
        s.audiosource.Stop();
    }
}
