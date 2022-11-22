using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid.Data
{
	[CreateAssetMenu(fileName = "In Game Config")]
	public class InGameConfig : ScriptableObject
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private LayerMask playerLayer;

		[Header("Scenes")]
		[SerializeField] private int mainMenuIndex;
		[SerializeField] private Vector2Int gameplayScenesRange;
		#endregion

		#region PROPERTIES
		public LayerMask PlayerLayer { get { return playerLayer; } }
		public int MainMenu { get { return mainMenuIndex; } }
		public int GameplayScenesCount { get { return gameplayScenesRange.y - gameplayScenesRange.x + 1; } }
		#endregion

		public int GetGameplaySceneIndex(int index)
		{
			return index % gameplayScenesRange.y + gameplayScenesRange.x;
		}
	}
}

