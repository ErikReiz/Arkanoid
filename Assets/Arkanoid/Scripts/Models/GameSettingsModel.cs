using Arkanoid.Data;
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

		#region PROPERTIES
		public ref SettingsSaveData Settings { get { return ref settingsPresset; } }
		#endregion

		#region FIELDS
		[Inject] private AudioMixer audioMixer;

		private SettingsSaveData settingsPresset;
		#endregion

		public void InitializeSettings(SettingsSaveData savedSettings)
		{
			settingsPresset = savedSettings;
			ApplySettings();
		}

		public void ApplySettings()
		{
			QualitySettings.resolutionScalingFixedDPIFactor = settingsPresset.ResolutionScale;
			audioMixer.SetFloat(sfxGroup, settingsPresset.SFXVolume);
			audioMixer.SetFloat(musicGroup, settingsPresset.MusicVolume);
		}

		public void ChangeResolutionScale(float scale)
		{
			settingsPresset.ResolutionScale = scale;
		}

		public void ChangeSFXVolume(bool isOn)
		{
			settingsPresset.SFXVolume = isOn ? 0 : -80;
		}

		public void ChangeMusicVolume(bool isOn)
		{
			settingsPresset.MusicVolume = isOn ? 0 : -80;
		}

	}
}

