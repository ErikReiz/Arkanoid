using System.Collections;
using System.Collections.Generic;
using Unity.RemoteConfig;
using UnityEngine;

namespace Arkanoid.Data
{
	[CreateAssetMenu(fileName = "Remote Config")]
	public class RemoteConfig : ScriptableObject
	{
		#region CONST
		private readonly string gameSettings = "Game settings";
		#endregion

		#region SERIALIZABLE FIELDS
		[SerializeField, HideInInspector] private float bonusFallSpeed;

		[Header("Bonuses")]
		[SerializeField, HideInInspector] private float sizeBonusMultiplier;
		#endregion

		public void L()
		{
			Debug.Log(ConfigManager.appConfig.GetJson(gameSettings).);
		}

		private void InitializeFields()
		{

		}
	}
}