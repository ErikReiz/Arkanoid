using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace Arkanoid.Models
{
    public class GameSettingsModel
    {
        #region CONST
        private readonly string sfxGroup = "SFX";
        private readonly string musicGroup = "Music";
        #endregion

        #region FIELDS
        [Inject] private AudioMixer audioMixer;
        #endregion

        
    }
}

