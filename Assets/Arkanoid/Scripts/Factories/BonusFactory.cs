using Arkanoid.Data;
using Arkanoid.Gameplay.Bonuses;
using Arkanoid.Interfaces;
using Arkanoid.Models;
using UnityEngine;

namespace Arkanoid.Patterns.Factories
{
	public class BonusFactory : IBonusFactory
	{
		#region FIELDS
		private System.Func<BaseBonus>[] bonusCreateFunc;
		private IBonusVisitor bonusVisitor;
		private PauseModel pauseModel;
		private InGameConfig config;
		#endregion

		public BonusFactory(IBonusVisitor bonusVisitor, PauseModel pauseModel, InGameConfig config)
		{
			this.bonusVisitor = bonusVisitor;
			this.pauseModel = pauseModel;
			this.config = config;

			bonusCreateFunc = new System.Func<BaseBonus>[] { PlatformSizeBonus, BallCountBonus };
		}

		private BaseBonus PlatformSizeBonus()
		{
			return new PlatformSizeBonus(bonusVisitor);
		}

		private BaseBonus BallCountBonus()
		{
			return new BallCountBonus(bonusVisitor);
		}

		public void Create(Vector3 spawnPosition)
		{
			BonusCarrier bonusObject = GameObject.Instantiate<BonusCarrier>(config.BonusCarrierPrefab, spawnPosition, Quaternion.identity);

			int randomIndex = Random.Range(0, bonusCreateFunc.Length);
			BaseBonus bonus = bonusCreateFunc[randomIndex].Invoke();
			bonusObject.Initialize(pauseModel, config, bonus);
		}
	}
}

