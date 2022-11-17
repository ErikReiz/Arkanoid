using UnityEngine.Events;

namespace Arkanoid.Interfaces
{
	public interface IScenesMenuView : IView
	{
		#region EVENTS
		public event UnityAction OnBackButtonClicked;
		#endregion

		#region METHODS
		void UpdateScenesList(int scenesCount);
		#endregion
	}
}
