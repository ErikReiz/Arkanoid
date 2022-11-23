using UnityEngine;

namespace Arkanoid.Interfaces
{
	public interface IBonusFactory
	{
		#region METHODS
		public void Create(Vector3 spawnPosition);
		#endregion
	}
}