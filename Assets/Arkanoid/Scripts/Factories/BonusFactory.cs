using Arkanoid.Data;
using Arkanoid.Gameplay.Bonuses;
using Arkanoid.Interfaces;
using Arkanoid.Models;
using UnityEngine;
using Zenject;

namespace Arkanoid.Patterns.Factories
{
	public class BonusFactory : IBonusFactory
	{
		#region FIELDS
		private System.Func<BaseBonus>[] bonusCreateFunc;
		private IBonusVisitor bonusVisitor;
		private InGameConfig config;
		private DiContainer diContainer;
		private RemoteConfig remoteConfig;
		#endregion

		public BonusFactory(IBonusVisitor bonusVisitor, InGameConfig config, DiContainer diContainer, RemoteConfig remoteConfig)
		{
			this.bonusVisitor = bonusVisitor;
			this.config = config;
			this.diContainer = diContainer;
			this.remoteConfig = remoteConfig;

			bonusCreateFunc = new System.Func<BaseBonus>[] { PlatformSizeBonus, BallCountBonus };
		}

		private BaseBonus PlatformSizeBonus()
		{
			return new PlatformSizeBonus(bonusVisitor, remoteConfig);
		}

		private BaseBonus BallCountBonus()
		{
			return new BallCountBonus(bonusVisitor, remoteConfig);
		}

		public void Create(Vector3 spawnPosition)
		{
			BonusCarrier bonusObject = diContainer.InstantiatePrefabForComponent<BonusCarrier>(config.BonusCarrierPrefab, spawnPosition, Quaternion.identity, null);

			int randomIndex = Random.Range(0, bonusCreateFunc.Length);
			BaseBonus bonus = bonusCreateFunc[randomIndex].Invoke();
			bonusObject.Initialize(bonus);
		}
	}
}

