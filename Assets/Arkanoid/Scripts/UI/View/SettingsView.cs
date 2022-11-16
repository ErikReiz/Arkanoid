using Arkanoid.Interfaces;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Arkanoid.UI.View
{
	public class SettingsView : MonoBehaviour, ISettingsView
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private Canvas canvas;

		[Header("Buttons")]
		[SerializeField] private Button applyButton;
		[SerializeField] private Button backButton;
		[SerializeField] private Toggle sfxToggle;
		[SerializeField] private Toggle musicToggle;

		[Header("DotWeen")]
		[SerializeField] private float tweeningLength = 0.3f;
		[SerializeField] private int hideDeltaChange = 1000;
		#endregion

		#region FIELDS
		public event UnityAction OnBackButtonClicked;
		public event UnityAction OnApplyButtonClicked;
		public event UnityAction<float> OnResolutionScaleChanged;
		public event UnityAction<bool> OnSFXVolumeChanged;
		public event UnityAction<bool> OnMusicVolumeChanged;
        #endregion

        private void OnEnable()
		{
			applyButton.onClick.AddListener(OnApplyClicked);
			backButton.onClick.AddListener(OnBackClicked);
			sfxToggle.onValueChanged.AddListener(OnSFXToggled);
			musicToggle.onValueChanged.AddListener(OnMusicToggled);
		}

		private void OnDisable()
		{
			applyButton.onClick.RemoveListener(OnApplyClicked);
			backButton.onClick.RemoveListener(OnBackClicked);
			sfxToggle.onValueChanged.RemoveListener(OnSFXToggled);
			musicToggle.onValueChanged.RemoveListener(OnMusicToggled);
		}

		private void OnApplyClicked()
		{
			applyButton.transform.DOShakeScale(tweeningLength);
			OnApplyButtonClicked.Invoke();
		}

		private async void OnBackClicked()
		{
			await Hide();
			canvas.gameObject.SetActive(false);
			OnBackButtonClicked.Invoke();
		}

		private void OnSFXToggled(bool isOn)
		{
			OnSFXVolumeChanged.Invoke(isOn);
		}

		private void OnMusicToggled(bool isOn)
		{
			OnMusicVolumeChanged.Invoke(isOn);
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
	}
}