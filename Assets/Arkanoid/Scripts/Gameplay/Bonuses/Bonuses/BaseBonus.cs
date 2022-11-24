using Arkanoid.Interfaces;

namespace Arkanoid.Gameplay.Bonuses
{
	public abstract class BaseBonus
	{
		#region FIELDS
		protected IBonusVisitor bonusVisitor;
		#endregion

		protected BaseBonus(IBonusVisitor bonusVisitor)
		{
			this.bonusVisitor = bonusVisitor;
		}

		public abstract void Activate();
	}
}