using Arkanoid.UI.Presenter;
using Zenject;

namespace Arkanoid.Managers
{
	public class GameManager
	{
		#region FIELDS
		[Inject] private LoadPresenter loadPresenter;

		private int ballsCount = 1;
		#endregion

		public void OnBallDestroyed()
		{
			ballsCount--;

			if(ballsCount <= 0)
				EndGame();
		}

		private void EndGame()
		{
			ballsCount = 1;
			loadPresenter.ReloadScene();
		}
	}
}