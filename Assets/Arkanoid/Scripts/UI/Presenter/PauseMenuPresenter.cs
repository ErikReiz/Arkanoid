using Arkanoid.Interfaces;
using Arkanoid.Models;
using Zenject;

namespace Arkanoid.UI.Presenter
{
	public class PauseMenuPresenter : BasePresenter
	{
		#region FIELDS
		[Inject] private HudPresenter hudPresenter;
		[Inject] private LoadPresenter loadScenePresenter;
		[Inject] private IView menuView;

		private PauseModel pauseModel;
		#endregion

		public PauseMenuPresenter(PauseModel pauseModel)
		{
			this.pauseModel = pauseModel;
		}

		public void Play()
		{
			pauseModel.PauseGame(false);
			hudPresenter.Run();
		}

		public void Quit()
		{
			pauseModel.PauseGame(false);
			loadScenePresenter.LoadMainMenu();
		}

		public override void Run()
		{
			pauseModel.PauseGame(true);
			menuView.Show();
		}
	}
}