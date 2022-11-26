using Arkanoid.Gameplay.Platform;

namespace Arkanoid.Interfaces
{
	public interface IBallFactory
	{
		#region METHODS
		public void BindPlayer(Player player);
		public void Create(int ballCount);
		#endregion
	}
}