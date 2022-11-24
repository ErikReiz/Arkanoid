using Arkanoid.Interfaces;

namespace Arkanoid.Gameplay.Bonuses
{
	public class BallCountBonus : BaseBonus
	{
		#region PROPERTIES
		public int BallIncrease { get { return ballIncrease; } }
		#endregion

		#region FIELDS
		private int ballIncrease = 1; //TODO переместить в конфиг
		#endregion

		public BallCountBonus(IBonusVisitor bonusVisitor) : base(bonusVisitor) { }

		public override void Activate()
		{
			bonusVisitor.Visit(this);
		}
	}
}