using Arkanoid.Data;
using Arkanoid.Interfaces;
using Arkanoid.Managers;
using UnityEngine;
using Zenject;

namespace Arkanoid.Gameplay.Tiles
{
	[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
	public class Tile : MonoBehaviour
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private TileData tileData;
		#endregion

		#region FIELDS
		[Inject] private IBonusFactory bonusFactory;
		[Inject] private GameManager gameManager;

		private int tileHealth;
		#endregion

		private void Awake()
		{
			SpriteRenderer renderer = GetComponent<SpriteRenderer>();
			renderer.sprite = tileData.TileSprite;
			renderer.color = tileData.TileColor;

			tileHealth = tileData.TileHealth;
		}

		private void Start()
		{
			gameManager.IncreaseTileCount();
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			tileHealth--;
			if (tileHealth <= 0)
				Die();
		}

		private void Die()
		{
			if (Random.Range(0, 100) <= tileData.BonusSpawnChance)
				bonusFactory.Create(transform.position);

			gameManager.OnTileDestroyed(tileData.Score);
			Destroy(gameObject);
		}
	}
}