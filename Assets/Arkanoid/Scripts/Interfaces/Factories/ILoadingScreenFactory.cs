namespace Arkanoid.Interfaces
{
	public interface ILoadingScreenFactory
	{
		#region METHODS
		public ILoadingView Create();
		public void Unload();
		#endregion
	}
}