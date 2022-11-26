using Arkanoid.Data;
using Arkanoid.Interfaces;
using Zenject;

namespace Arkanoid.Gameplay.Bonuses
{
	public class BallCountBonus : BaseBonus
	{
		#region PROPERTIES
		public int BallIncrease { get { return remoteConfig.BonusBallIncreaseSize; } }
		#endregion

		#region FIELDS
		[Inject] private RemoteConfig config;
		#endregion

		public BallCountBonus(IBonusVisitor bonusVisitor, RemoteConfig config) : base(bonusVisitor, config) { }

		public override void Activate()
		{
			bonusVisitor.Visit(this);
		}
	}
}