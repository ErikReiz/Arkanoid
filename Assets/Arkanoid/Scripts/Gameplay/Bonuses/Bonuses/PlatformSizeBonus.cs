using Arkanoid.Data;
using Arkanoid.Interfaces;
using Zenject;

namespace Arkanoid.Gameplay.Bonuses
{
	public class PlatformSizeBonus : BaseBonus, IBonusWithTimer
	{
		#region PROPERTIES
		public float SizeModifier { get { return remoteConfig.SizeBonusMultiplier; } }
		#endregion

		#region FIELDS
		private float bonusTime;
		#endregion

		public PlatformSizeBonus(IBonusVisitor bonusVisitor, RemoteConfig config) : base(bonusVisitor, config)
		{
			bonusTime = config.SizeBonusTimer;
		}

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