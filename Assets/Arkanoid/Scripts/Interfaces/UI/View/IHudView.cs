using UnityEngine.Events;

namespace Arkanoid.Interfaces
{
	public interface IHudView : IView
	{
		#region EVENTS
		public event UnityAction OnPauseButtonClicked;
		#endregion
	}
}