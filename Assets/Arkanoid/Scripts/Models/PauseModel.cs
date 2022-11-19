namespace Arkanoid.Models
{
	public class PauseModel
	{
		#region PROPERTIES
		public bool IsPaused { get; private set; }
		#endregion

		public void PauseGame(bool isPaused)
		{
			IsPaused = isPaused;
		}
	}
}