using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid.Data
{
    [System.Serializable]
    public struct SettingsSaveData
    {
        private bool isSFXTurnedOn;
        private bool isMusicTurnedOn;
        private float resolutionScale;

        public bool IsSFXTurnedOn { get { return isSFXTurnedOn; } set { isSFXTurnedOn = value; } }
        public bool IsMusicTurnedOn { get { return isMusicTurnedOn; } set { isMusicTurnedOn = value; } }

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

