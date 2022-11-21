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
			OnPauseButtonClicked.Invoke();
		}

		public Task Show()
		{
			return null;
		}

		public Task Hide()
		{
			return null;
		}
	}
}