using Arkanoid.UI.Presenter;

namespace Arkanoid.Interfaces
{
	public interface ILoadingView : IView
	{
		#region METHODS
		public void Initialize(LoadPresenter presenter);
		public void StartLoading();
		#endregion
	}
}