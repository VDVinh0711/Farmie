
using UnityEngine;
using System;

namespace SoundManager
{
    [Serializable]
    public class Sound 
    {
        public string namesound;
        public AudioClip sound;

        public Sound(string namesound, AudioClip sound)
        {
            this.namesound = namesound;
            this.sound = sound;
        }
    }
    
}


