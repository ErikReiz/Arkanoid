using UnityEngine;

namespace Arkanoid.Interfaces
{
	public interface ILoadingView : IView
	{
		#region METHODS
		public void StartLoading(AsyncOperation loadingOperation);
		public AsyncOperation LoadingOperation { set; }
		#endregion
	}
}