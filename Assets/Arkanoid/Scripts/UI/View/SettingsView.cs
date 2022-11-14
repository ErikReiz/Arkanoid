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
		[SerializeField] private Button backButton;

		[Header("DotWeen")]
		[SerializeField] private float tweeningLength = 0.3f;
		[SerializeField] private int hideDeltaChange = 1000;
		#endregion

		#region FIELDS
		public event UnityAction OnBackButtonClicked;
		public event UnityAction<float> OnResolutionScaleChanged;
		public event UnityAction<bool> OnSoundVolumeChanged;
		public event UnityAction<bool> OnMusicVolumeChanged;
		#endregion

		private void OnEnable()
		{
			backButton.onClick.AddListener(OnBackClicked);
		}

		private void OnDisable()
		{
			backButton.onClick.RemoveListener(OnBackClicked);
		}

		private async void OnBackClicked()
		{
			await Hide();
			canvas.gameObject.SetActive(false);
			OnBackButtonClicked.Invoke();
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