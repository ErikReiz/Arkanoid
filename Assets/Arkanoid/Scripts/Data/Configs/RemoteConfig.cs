using System.Collections;
using System.Collections.Generic;
using Unity.RemoteConfig;
using UnityEngine;

namespace Arkanoid.Data
{
	[System.Serializable]
	public struct RemoteConfigStruct
	{
		public float bonusFallSpeed;
		public float sizeBonusMultiplier;
		public float sizeBonusTimer;
		public int bonusBallIncrease;

		public float ballStartSpeed;
		public float ballMaxSpeed;
		public float increaseSpeedFactor;
		public float increaseDelay;
	}

	public class RemoteConfig
	{
		#region CONST
		private readonly string gameSettings = "Game settings";
		#endregion

		#region PROPERTIES
		public float BonusFallSpeed { get { return remoteConfigStruct.bonusFallSpeed; } }
		public float SizeBonusMultiplier { get { return remoteConfigStruct.sizeBonusMultiplier; } }
		public float SizeBonusTimer { get { return remoteConfigStruct.sizeBonusTimer; } }
		public int BonusBallIncreaseSize { get { return remoteConfigStruct.bonusBallIncrease; } }

		public float BallStartSpeed { get { return remoteConfigStruct.ballStartSpeed; } }
		public float BallMaxSpeed { get { return remoteConfigStruct.ballMaxSpeed; } }
		public float IncreaseSpeedFactor { get { return remoteConfigStruct.increaseSpeedFactor; } }
		public float IncreaseDelay { get { return remoteConfigStruct.increaseDelay; } }
		#endregion

		#region FIELDS
		private RemoteConfigStruct remoteConfigStruct;
		#endregion

		public RemoteConfig()
		{
			InitializeConfig();
		}

		private void InitializeConfig()
		{
			string json = ConfigManager.appConfig.GetJson(gameSettings);
			remoteConfigStruct = JsonUtility.FromJson<RemoteConfigStruct>(json);
		}

	}
}