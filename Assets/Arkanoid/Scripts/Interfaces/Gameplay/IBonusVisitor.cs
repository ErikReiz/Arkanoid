using Arkanoid.Gameplay.Bonuses;

namespace Arkanoid.Interfaces
{
	public interface IBonusVisitor
	{
		public void Visit(PlatformSizeBonus visitor);
	}
}