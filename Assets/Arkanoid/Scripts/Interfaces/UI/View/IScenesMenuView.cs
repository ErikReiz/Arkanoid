using UnityEngine.Events;

namespace Arkanoid.Interfaces
{
	public interface IScenesMenuView : IView
	{
		#region EVENTS
		public event UnityAction OnBackButtonClicked;
		public event UnityAction<int> OnSceneButtonClicked;
		#endregion

		#region METHODS
		void UpdateScenesList(int scenesCount);
		#endregion
	}
}
