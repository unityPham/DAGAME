using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public bool soundsMute;

    public static AudioManager THIS;
    void Awake()
    {
        THIS = this;
        gameObject.AddComponent<AudioSource>();
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.mute = s.mute;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
        
    }


    private void Start()
    {

    }
    public void SetVolume(Sound_Name name, float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.soundName == name);
        if (s == null)
        {
            Debug.LogWarning("Sound  ''" + name + "''  not found!");
            return;
        }
        s.source.volume = volume;
        Debug.Log("set '" + name + "' volume to: " + volume);
    }


    // Update is called once per frame
    public void Play(Sound_Name name)
    {
        Sound s = Array.Find(sounds, sound => sound.soundName == name);
        if (s == null)
        {
            Debug.LogWarning("Sound  ''" + name + "''  not found!");
            return;
        }
        s.source.Play();
    }

    public void Stop(Sound_Name name)
    {
        Sound s = Array.Find(sounds, sound => sound.soundName == name);
        if (s == null)
        {
            Debug.LogWarning("Sound  ''" + name + "''  not found!");
            return;
        }
        s.source.Stop();
    }

    public void StopAll()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }

    private void Update()
    {
        CheckMute();
    }

    void CheckMute()
    {
        if (soundsMute != GameManager.THIS.mute)
        {
            foreach (Sound s in sounds)
            {
                s.source.mute = GameManager.THIS.mute;
            }
            soundsMute = GameManager.THIS.mute;
        }
    }

}
