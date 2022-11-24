using Arkanoid.Interfaces;

namespace Arkanoid.Gameplay.Bonuses
{
	public class PlatformSizeBonus : BaseBonus, IBonusWithTimer
	{
		#region PROPERTIES
		public float SizeModifier { get { return sizeModifier; } }
		#endregion

		#region FIELDS
		private float sizeModifier = 1.5f; //TODO переместить в конфиг
		private int bonusTime = 10;
		#endregion

		public PlatformSizeBonus(IBonusVisitor bonusVisitor) : base(bonusVisitor) {}

		private void Diactivate()
		{
			bonusVisitor.Visit(this, false);
		}

		public override void Activate()
		{
			bonusVisitor.Visit(this, true);
		}

		public void UpdateTime()
		{
			bonusTime--;
			if (bonusTime <= 0)
				Diactivate();
		}
	}
}