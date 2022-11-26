using Arkanoid.Data;
using Arkanoid.Interfaces;

namespace Arkanoid.Gameplay.Bonuses
{
	public abstract class BaseBonus
	{
		#region FIELDS
		protected IBonusVisitor bonusVisitor;
		protected RemoteConfig remoteConfig;
		#endregion

		protected BaseBonus(IBonusVisitor bonusVisitor, RemoteConfig remoteConfig)
		{
			this.bonusVisitor = bonusVisitor;
			this.remoteConfig = remoteConfig;
		}

		public abstract void Activate();
	}
}