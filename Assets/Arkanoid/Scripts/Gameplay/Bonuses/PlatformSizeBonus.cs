namespace Arkanoid.Gameplay.Bonuses
{
	public class PlatformSizeBonus : BaseBonus
	{
		#region PROPERTIES
		public float SizeModifier { get { return sizeModifier; } }
		#endregion

		#region FIELDS
		private float sizeModifier;
		#endregion

		public PlatformSizeBonus()
		{
			sizeModifier = 1.5f;
		}

		public override void Activate()
		{
			bonusVisitor.Visit(this);
		}
	}
}