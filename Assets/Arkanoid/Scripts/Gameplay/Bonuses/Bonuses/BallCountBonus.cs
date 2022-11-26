using Arkanoid.Data;
using Arkanoid.Interfaces;
using Zenject;

namespace Arkanoid.Gameplay.Bonuses
{
	public class BallCountBonus : BaseBonus
	{
		#region PROPERTIES
		public int BallIncrease { get { return config.BonusBallIncreaseSize; } }
		#endregion

		#region FIELDS
		[Inject] private RemoteConfig config;
		#endregion

		public BallCountBonus(IBonusVisitor bonusVisitor) : base(bonusVisitor) { }

		public override void Activate()
		{
			bonusVisitor.Visit(this);
		}
	}
}