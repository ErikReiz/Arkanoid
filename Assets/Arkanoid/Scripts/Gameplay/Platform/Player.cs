using Arkanoid.Gameplay.Bonuses;
using Arkanoid.Interfaces;
using UnityEngine;

namespace Arkanoid.Gameplay.Platform
{
	public class Player : MonoBehaviour, IBonusVisitor
	{
		public void Visit(PlatformSizeBonus visitor)
		{
			Debug.Log("visit");
		}
	}
}