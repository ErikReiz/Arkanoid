using Arkanoid.Interfaces;
using Arkanoid.Managers;
using Arkanoid.Models;
using Zenject;

namespace Arkanoid.UI.Presenter
{
	public class PauseMenuPresenter : BasePresenter
	{
		#region FIELDS
		[Inject] private GameManager gameManager;
		[Inject] private HudPresenter hudPresenter;
		[Inject] private LoadPresenter loadScenePresenter;
		[Inject] private IView menuView;
		[Inject] private IScoreMenuView sceneMenuView;

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

		public void LoadNextLevel()
		{
			pauseModel.PauseGame(false);
			loadScenePresenter.LoadNextScene();
		}

		public void QuitToMainMenu()
		{
			pauseModel.PauseGame(false);
			loadScenePresenter.LoadMainMenu();
		}

		public override void Run()
		{	
			pauseModel.PauseGame(true);

			if (gameManager.IsGameEnded)
			{
				sceneMenuView.Show();
				sceneMenuView.UpdateScore(gameManager.Score);
			}
			else
			{
				menuView.Show();
			}

		}
	}
}