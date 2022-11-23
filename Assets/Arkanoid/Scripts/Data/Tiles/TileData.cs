using UnityEngine;

namespace Arkanoid.Data
{
	[CreateAssetMenu(fileName = "TileConfig")]
	public class TileData : ScriptableObject
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private Sprite tileSprite;
		[SerializeField] private Color tileColor;
		[SerializeField] private int tileHealth;
		[SerializeField] private float bonusSpawnChance;
		#endregion

		#region PROPERTIES
		public Sprite TileSprite { get { return tileSprite; } }
		public Color TileColor { get { return tileColor; } }
		public int TileHealth { get { return tileHealth; } }
		public float BonusSpawnChance { get { return bonusSpawnChance; } }
		#endregion
	}
}