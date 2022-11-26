using Arkanoid.Gameplay.Bonuses;
using Arkanoid.Gameplay.Platform;
using Unity.RemoteConfig;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid.Data
{
	[CreateAssetMenu(fileName = "In Game Config")]
	public class InGameConfig : ScriptableObject
	{
		#region CONST
		private readonly string gameSettings = "Game settings";
		#endregion

		#region SERIALIZABLE FIELDS
		[SerializeField] private LayerMask playerLayer;

		[Header("Prefabs")]
		[SerializeField] private BonusCarrier bonusCarrierPrefab;
		[SerializeField] private Ball ballPrefab;

		[Header("Scenes")]
		[SerializeField] private int mainMenuIndex;
		[SerializeField] private Vector2Int gameplayScenesRange;
		#endregion

		#region PROPERTIES
		public LayerMask PlayerLayer { get { return playerLayer; } }
		public BonusCarrier BonusCarrierPrefab { get { return bonusCarrierPrefab; } }
		public Ball BallPrefab { get { return ballPrefab; } }
		public int MainMenu { get { return mainMenuIndex; } }
		public int GameplayScenesCount { get { return gameplayScenesRange.y - gameplayScenesRange.x + 1; } }
		#endregion

		public int GetGameplaySceneIndex(int index)
		{
			if (index > gameplayScenesRange.y)
				return mainMenuIndex;

			return index % gameplayScenesRange.y + gameplayScenesRange.x;
		}
	}
}

