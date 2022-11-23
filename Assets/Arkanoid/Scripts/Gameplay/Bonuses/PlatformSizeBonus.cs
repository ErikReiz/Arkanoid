using Arkanoid.Interfaces;

namespace Arkanoid.Gameplay.Bonuses
{
	public class PlatformSizeBonus : BaseBonus
	{
		#region PROPERTIES
		public float SizeModifier { get { return sizeModifier; } }
		public int BonusTime { get { return bonusTime; } }
		#endregion

		#region FIELDS
		private float sizeModifier = 1.5f; //TODO переместить в конфиг
		private int bonusTime = 5;
		#endregion

		public PlatformSizeBonus(IBonusVisitor bonusVisitor) : base(bonusVisitor) {}

		public override void Activate()
		{
			bonusVisitor.Visit(this);
		}
	}
}