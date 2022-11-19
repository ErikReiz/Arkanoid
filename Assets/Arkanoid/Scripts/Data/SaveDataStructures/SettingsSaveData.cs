using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid.Data
{
    [System.Serializable]
    public struct SettingsSaveData
    {
        private float sfxVolume;
        private float musicVolume;
        private float resolutionScale;

        public float SFXVolume { get { return sfxVolume; } set { sfxVolume = value; } }
        public float MusicVolume { get { return musicVolume; } set { musicVolume = value; } }

        public float ResolutionScale
        { 
            get { return resolutionScale; }
            set 
            { 
                if(value >= 0 && value <= 1)
                    resolutionScale = value;
            }
        }
    }
}

