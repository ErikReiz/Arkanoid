namespace Arkanoid.Managers
{
	public class GameManager
	{
		#region FIELDS
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
			UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
		}
	}
}