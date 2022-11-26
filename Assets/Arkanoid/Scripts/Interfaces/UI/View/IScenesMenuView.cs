using UnityEngine.Events;

namespace Arkanoid.Interfaces
{
	public interface IScenesMenuView : IView
	{
		#region METHODS
		void UpdateScenesList(int scenesCount);
		#endregion
	}
}
