using Arkanoid.UI.Presenter;

namespace Arkanoid.Interfaces
{
	public interface ILoadingScreenFactory
	{
		#region METHODS
		public ILoadingView Create(LoadPresenter loadPresenter);
		public void Unload();
		#endregion
	}
}