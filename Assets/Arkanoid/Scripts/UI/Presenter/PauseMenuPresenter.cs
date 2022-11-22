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

		private IPauseMenuView menuView;
		private PauseModel pauseModel;
		#endregion

		public PauseMenuPresenter(IPauseMenuView view, PauseModel pauseModel)
		{
			menuView = view;
			this.pauseModel = pauseModel;

			menuView.OnPlayButtonClicked += Play;
			menuView.OnQuitButtonClicked += Quit;
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