using UnityEngine;

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
        [HideInInspector]
        public AudioSource audiosource;
    }
}
