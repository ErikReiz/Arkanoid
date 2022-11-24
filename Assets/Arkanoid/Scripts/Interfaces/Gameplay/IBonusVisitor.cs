using Arkanoid.Gameplay.Bonuses;

namespace Arkanoid.Interfaces
{
	public interface IBonusVisitor
	{
		public void Visit(PlatformSizeBonus visitor, bool isActivated);
		public void Visit(BallCountBonus visitor);
	}
}