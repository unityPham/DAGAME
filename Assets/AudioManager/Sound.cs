using UnityEngine.Audio;
using UnityEngine;

public enum Sound_Name
{
    baby,
    father,
    mother,
    mexican,
    boom,
    coin,
    over,
    introOver,
}

[System.Serializable]

public class Sound
{
    public Sound_Name soundName;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;

    public bool loop;

    public bool playOnAwake;

    public bool mute;

    [HideInInspector]
    public AudioSource source;
}
