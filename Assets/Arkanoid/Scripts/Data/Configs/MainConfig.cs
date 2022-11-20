using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid.Data
{
	[CreateAssetMenu(fileName = "Config")]
	public class MainConfig : ScriptableObject
	{
		#region SERIALIZABLE FIELDS
		[Header("Scenes")]
		[SerializeField] private int mainMenuIndex;
		[SerializeField] private Vector2Int gameplayScenesRange;
		#endregion

		#region PROPERTIES
		public int MainMenu { get { return mainMenuIndex; } }
		public int GameplayScenesCount { get { return gameplayScenesRange.y - gameplayScenesRange.x + 1; } }
		#endregion

		public int GetGameplaySceneIndex(int index)
		{
			return index % gameplayScenesRange.y + gameplayScenesRange.x;
		}
	}
}

