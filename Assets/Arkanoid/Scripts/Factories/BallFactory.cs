using Arkanoid.Data;
using Arkanoid.Gameplay.Platform;
using Arkanoid.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Arkanoid.Patterns.Factories
{
	public class BallFactory : IBallFactory
	{
		#region FIELDS
		private Player player;
		private InGameConfig config;
		private DiContainer diContainer;
		#endregion

		public BallFactory(InGameConfig config, DiContainer diContainer)
		{
			this.config = config;
			this.diContainer = diContainer;
		}

		public void BindPlayer(Player player)
		{
			this.player = player;
		}

		public void Create(int ballCount)
		{
			for(int i = 0; i < ballCount; i++)
				diContainer.InstantiatePrefab(config.BallPrefab, player.BallSpawnPosition(), Quaternion.identity, null);
		}
	}
}