using Arkanoid.Interfaces;
using Arkanoid.UI.Presenter;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using TMPro;

namespace Arkanoid.UI.View
{
	public class ScoreMenuView : MonoBehaviour, IScoreMenuView
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private Canvas canvas;
		[SerializeField] private TMP_Text scoreText;

		[Header("Buttons")]
		[SerializeField] private Button nextSceneButton;
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
			nextSceneButton.onClick.AddListener(OnNextLevelClicked);
			quitButton.onClick.AddListener(OnQuitToMenuClicked);
		}

		private void OnDisable()
		{
			nextSceneButton.onClick.RemoveListener(OnNextLevelClicked);
			quitButton.onClick.RemoveListener(OnQuitToMenuClicked);
		}

		private async void OnNextLevelClicked()
		{
			await Hide();
			canvas.gameObject.SetActive(false);
			menuPresenter.LoadNextLevel();
		}

		private async void OnQuitToMenuClicked()
		{
			await Hide();
			canvas.gameObject.SetActive(false);
			menuPresenter.QuitToMainMenu();
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

		public void UpdateScore(int score)
		{
			scoreText.SetText($"Score {score}");
		}
	}
}