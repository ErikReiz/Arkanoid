using UnityEngine;

namespace Arkanoid.Data
{
	[CreateAssetMenu(fileName = "Scenes Data")]
	public class ScenesData : ScriptableObject
	{
		#region SERIALIZABLE FIELDS
		[Tooltip("Gameplay levels")]
		[SerializeField] private Object[] scenes;
		[SerializeField] private Object mainMenu;
		#endregion

		#region PROPERTIES
		public Object[] Scenes { get { return scenes; } }
		public Object MainMenu { get { return mainMenu; } }
		#endregion 

	}
}

