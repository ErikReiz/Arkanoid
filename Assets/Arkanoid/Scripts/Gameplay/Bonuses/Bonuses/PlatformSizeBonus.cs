using Arkanoid.Data;
using Arkanoid.Interfaces;
using Zenject;

namespace Arkanoid.Gameplay.Bonuses
{
	public class PlatformSizeBonus : BaseBonus, IBonusWithTimer
	{
		#region PROPERTIES
		public float SizeModifier { get { return config.SizeBonusMultiplier; } }
		#endregion

		#region FIELDS
		[Inject] private RemoteConfig config;

		private float bonusTime;
		#endregion

		public PlatformSizeBonus(IBonusVisitor bonusVisitor) : base(bonusVisitor)
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