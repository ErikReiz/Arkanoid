using UnityEditor;
using UnityEngine;

namespace Arkanoid.Data
{
	[CreateAssetMenu(fileName = "Scenes Data")]
	public class MainConfig : ScriptableObject
	{
		#region SERIALIZABLE FIELDS
		[Tooltip("Gameplay levels")]
		[SerializeField] private SceneAsset[] scenes;
		[SerializeField] private SceneAsset mainMenu;
		#endregion

		#region PROPERTIES
		public SceneAsset[] Scenes { get { return scenes; } }
		public SceneAsset MainMenu { get { return mainMenu; } }
		#endregion 

	}
}

