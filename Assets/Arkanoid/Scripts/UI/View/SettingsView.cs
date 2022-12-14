using Arkanoid.Data;
using Arkanoid.Interfaces;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using Zenject;
using Arkanoid.UI.Presenter;

namespace Arkanoid.UI.View
{
	public class SettingsView : MonoBehaviour, ISettingsView
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private Canvas canvas;

		[Header("Buttons")]
		[SerializeField] private float resoluitonScaleStep = 0.25f;

		[SerializeField] private Button applyButton;
		[SerializeField] private Button backButton;
		[SerializeField] private TMP_Dropdown resolutionDropdown;
		[SerializeField] private Toggle sfxToggle;
		[SerializeField] private Toggle musicToggle;

		[Header("DotWeen")]
		[SerializeField] private float tweeningLength = 0.3f;
		[SerializeField] private int hideDeltaChange = 1000;
		#endregion

		#region FIELDS
		[Inject] private SettingsPresenter settingsPresenter;
		#endregion

		private void OnEnable()
		{
			applyButton.onClick.AddListener(ApplyClicked);
			backButton.onClick.AddListener(BackButtonClicked);
			resolutionDropdown.onValueChanged.AddListener(ChangeResolutionScale);
			sfxToggle.onValueChanged.AddListener(OnSFXToggled);
			musicToggle.onValueChanged.AddListener(OnMusicToggled);
		}

		private void OnDisable()
		{
			applyButton.onClick.RemoveListener(ApplyClicked);
			backButton.onClick.RemoveListener(BackButtonClicked);
			resolutionDropdown.onValueChanged.RemoveListener(ChangeResolutionScale);
			sfxToggle.onValueChanged.RemoveListener(OnSFXToggled);
			musicToggle.onValueChanged.RemoveListener(OnMusicToggled);
		}

		private void ApplyClicked()
		{
			settingsPresenter.ApplySettings();
		}

		private async void BackButtonClicked()
		{
			await Hide();
			canvas.gameObject.SetActive(false);
			settingsPresenter.BackToMenu();
		}

		private void ChangeResolutionScale(int index)
		{
			float scale = 1 - index * resoluitonScaleStep;
			settingsPresenter.ChangeResolutionScale(scale);
		}

		private void OnSFXToggled(bool isOn)
		{
			settingsPresenter.ChangeSFXVolume(isOn);
		}

		private void OnMusicToggled(bool isOn)
		{
			settingsPresenter.ChangeMusicVolume(isOn);
		}

		public Task Show()
		{
			canvas.gameObject.SetActive(true);
			return transform.DOLocalMoveX(0, tweeningLength).AsyncWaitForCompletion();
		}

		public Task Hide()
		{
			return transform.DOLocalMoveX(hideDeltaChange, tweeningLength).AsyncWaitForCompletion();
		}

		public void UpdateSettings(ref SettingsSaveData settingsSaveData)
		{
			int index = resolutionDropdown.options.Count - Mathf.FloorToInt(settingsSaveData.ResolutionScale / resoluitonScaleStep);
			bool isSFXToggled = settingsSaveData.SFXVolume < 0 ? false : true;
			bool isMusicToggled = settingsSaveData.MusicVolume < 0 ? false : true;

			resolutionDropdown.value = index;
			sfxToggle.isOn = isSFXToggled;
			musicToggle.isOn = isMusicToggled;

			resolutionDropdown.RefreshShownValue();
		}
	}
}