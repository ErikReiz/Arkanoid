using Arkanoid.Gameplay.Bonuses;
using Arkanoid.Interfaces;
using UnityEngine;

namespace Arkanoid.Patterns.Factories
{
	public class BonusFactory
	{
		#region FIELDS
		private System.Action<GameObject>[] bonusSpawnFunc;
		private IBonusVisitor bonusVisitor;
		#endregion

		public BonusFactory(IBonusVisitor bonusVisitor)
		{
			this.bonusVisitor = bonusVisitor;

			bonusSpawnFunc = new System.Action<GameObject>[] { PlatformSizeBonus };
		}

		public void GenerateBonus(Vector3 spawnPosition)
		{
			GameObject bonusObject = new GameObject("Bonus");
			bonusObject.transform.position = spawnPosition;

			int randomIndex = Random.Range(0, bonusSpawnFunc.Length);
			bonusSpawnFunc[randomIndex].Invoke(bonusObject);
		}

		private void PlatformSizeBonus(GameObject bonusObject)
		{
			bonusObject.AddComponent<PlatformSizeBonus>();
		}
	}
}

