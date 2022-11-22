using Arkanoid.Interfaces;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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
		public event UnityAction OnPauseButtonClicked;
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
			OnPauseButtonClicked.Invoke();
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