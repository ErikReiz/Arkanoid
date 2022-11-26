using System.Threading.Tasks;

namespace Arkanoid.Interfaces
{
	public interface IView
	{
		#region METHODS
		public Task Show();
		public Task Hide();
		#endregion
	}
}