using Arkanoid.Interfaces;

namespace Arkanoid.Gameplay.Bonuses
{
	public class PlatformSizeBonus : BaseBonus
	{
		public override void Activate()
		{
			bonusVisitor.Visit(this);
		}
	}
}