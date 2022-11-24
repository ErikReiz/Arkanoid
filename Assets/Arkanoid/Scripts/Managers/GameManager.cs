using Arkanoid.Data;
using Arkanoid.Gameplay.Platform;
using Arkanoid.Interfaces;
using Arkanoid.UI.Presenter;
using UnityEngine;
using Zenject;

namespace Arkanoid.Managers
{
	public class GameManager
	{
		#region FIELDS
		[Inject] private LoadPresenter loadPresenter;
		[Inject] private IBallFactory ballFactory;

		private int ballsCount = 1;
		#endregion

		private void EndGame()
		{
			ballsCount = 1;
			loadPresenter.ReloadScene();
		}
		
		public void OnBallDestroyed()
		{
			ballsCount--;

			if(ballsCount <= 0)
				EndGame();
		}

		public void IncreaseBallCount(int increaseCount)
		{
			ballsCount += increaseCount;
			ballFactory.Create(increaseCount);
		}
	}
}