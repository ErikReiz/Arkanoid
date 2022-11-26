using Arkanoid.Interfaces;
using Arkanoid.UI.Presenter;
using Zenject;

namespace Arkanoid.Managers
{
	public class GameManager
	{
		#region PROPERTIES
		public PauseMenuPresenter PauseMenuPresenter { private get; set; }
		public bool IsGameEnded { get; private set; }
		public int Score { get { return totalScore; } }
		#endregion

		#region FIELDS
		[Inject] private LoadPresenter loadPresenter;
		[Inject] private IBallFactory ballFactory;

		private int ballsCount = 1;
		private int tilesCount = 0;
		private int totalScore = 0;
		#endregion

		private void EndGame(bool isPlayerWinner)
		{


			IsGameEnded = true;

			if (isPlayerWinner)
				PauseMenuPresenter.Run();
			else
				loadPresenter.ReloadScene();

			IsGameEnded = false;
			tilesCount = 0;
			totalScore = 0;
			ballsCount = 1;
		}
		
		public void OnTileDestroyed(int score)
		{
			tilesCount--;
			totalScore += score;

			if(tilesCount <= 0)
				EndGame(true);
		}

		public void OnBallDestroyed()
		{
			ballsCount--;

			if(ballsCount <= 0)
				EndGame(false);
		}

		public void IncreaseBallCount(int increaseCount)
		{
			ballsCount += increaseCount;
			ballFactory.Create(increaseCount);
		}

		public void IncreaseTileCount()
		{
			tilesCount++;
		}
	}
}