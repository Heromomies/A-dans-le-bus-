using UnityEngine;
using UnityEngine.Audio;

namespace Sound
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip audioclip;
        [Range(0, 1)]
        public float volume;
        public bool loop;
        public AudioMixerGroup audioMixer;
        [HideInInspector]
        public AudioSource audiosource;
    }
}
