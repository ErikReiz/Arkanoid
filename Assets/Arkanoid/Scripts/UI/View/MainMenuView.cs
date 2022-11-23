using Arkanoid.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading.Tasks;
using Unity.RemoteConfig;
using Zenject;
using Arkanoid.UI.Presenter;

namespace Arkanoid.UI.View
{
	public class MainMenuView : MonoBehaviour, IView
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private Canvas canvas;		

		[Header("Buttons")]
		[SerializeField] private Button playButton;
		[SerializeField] private Button settingsButton;
		[SerializeField] private Button quitButton;

		[Header("DotWeen")]
		[SerializeField] private float tweeningLength = 0.3f;
		[SerializeField] private int hideDeltaChange = 1000;
		#endregion

		#region FIELDS
		[Inject] private MainMenuPresenter menuPresenter;
        #endregion

        private void OnEnable()
		{
			playButton.onClick.AddListener(OnPlayClicked);
			settingsButton.onClick.AddListener(OnSettingsClicked);
			quitButton.onClick.AddListener(OnQuitClicked);
		}

		private void OnDisable()
		{
			playButton.onClick.RemoveListener(OnPlayClicked);
			settingsButton.onClick.RemoveListener(OnSettingsClicked);
			quitButton.onClick.RemoveListener(OnQuitClicked);
		}

		private async void OnPlayClicked()
		{
			await Hide();
			canvas.gameObject.SetActive(false);
			menuPresenter.Play();
		}

		private async void OnSettingsClicked()
		{
			await Hide();
			canvas.gameObject.SetActive(false);
			menuPresenter.OpenSettings();
		}

		private void OnQuitClicked()
		{
			menuPresenter.Quit();
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