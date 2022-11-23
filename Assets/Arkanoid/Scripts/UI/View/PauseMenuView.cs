using Arkanoid.Interfaces;
using Arkanoid.UI.Presenter;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Arkanoid.UI.View
{
	public class PauseMenuView : MonoBehaviour, IView
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private Canvas canvas;

		[Header("Buttons")]
		[SerializeField] private Button playButton;
		[SerializeField] private Button quitButton;

		[Header("DotWeen")]
		[SerializeField] private float tweeningLength = 0.3f;
		[SerializeField] private int hideDeltaChange = 1000;
		#endregion

		#region FIELDS
		[Inject] private PauseMenuPresenter menuPresenter;
		#endregion

		private void OnEnable()
		{
			playButton.onClick.AddListener(OnPlayClicked);
			quitButton.onClick.AddListener(OnQuitClicked);
		}

		private void OnDisable()
		{
			playButton.onClick.RemoveListener(OnPlayClicked);
			quitButton.onClick.RemoveListener(OnQuitClicked);
		}

		private async void OnPlayClicked()
		{
			await Hide();
			canvas.gameObject.SetActive(false);
			menuPresenter.Play();
		}

		private async void OnQuitClicked()
		{
			await Hide();
			canvas.gameObject.SetActive(false);
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