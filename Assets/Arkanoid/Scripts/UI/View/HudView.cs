using Arkanoid.Interfaces;
using Arkanoid.UI.Presenter;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkanoid.UI.View
{
	public class HudView : MonoBehaviour, IHudView
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private Canvas canvas;

		[Header("Buttons")]
		[SerializeField] private Button pauseButton;
		#endregion

		#region FIELDS
		[Inject] private HudPresenter hudPresenter;
		#endregion

		private void OnEnable()
		{
			pauseButton.onClick.AddListener(PauseButtonClicked);
		}

		private void OnDisable()
		{
			pauseButton.onClick.RemoveListener(PauseButtonClicked);
		}

		private void PauseButtonClicked()
		{
			Hide();
			hudPresenter.PauseGame();
		}

		private void OnApplicationPause(bool pause)
		{
			if(pause)
				PauseButtonClicked();
		}

		public Task Show()
		{
			canvas.gameObject.SetActive(true);
			return null;
		}

		public Task Hide()
		{
			canvas.gameObject.SetActive(false);
			return null;
		}
	}
}