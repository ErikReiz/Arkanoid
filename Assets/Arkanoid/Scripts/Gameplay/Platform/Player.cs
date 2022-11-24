using Arkanoid.Gameplay.Bonuses;
using Arkanoid.Interfaces;
using Arkanoid.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Arkanoid.Gameplay.Platform
{
	public class Player : MonoBehaviour, IBonusVisitor
	{
		#region CONST
		private readonly float ballSpawnRange = 0.2f;
		private readonly float abovePlatformElevation = 0.2f;
		#endregion

		#region FIELDS
		[Inject] private GameManager gameManager;

		private List<IBonusWithTimer> activeBonuses = new();
		private List<int> bonusIndexToRemove = new();

		private Camera mainCamera;
		private BoxCollider2D collider;
		private SpriteRenderer spriteRenderer;
		private PlayerMovement playerMovement;
		#endregion

		private void Awake()
		{
			mainCamera = Camera.main;
			collider = GetComponent<BoxCollider2D>();
			spriteRenderer = GetComponent<SpriteRenderer>();
			playerMovement = GetComponent<PlayerMovement>();

			CalculateBorders();
		}

		private void Start()
		{
			StartCoroutine(Timer());
		}

		private void CalculateBorders()
		{
			float platformBorder = mainCamera.ScreenToWorldPoint(new Vector2(mainCamera.pixelWidth, transform.position.y)).x;
			platformBorder -= collider.bounds.size.x / 2;
			playerMovement.PlatformBorders = platformBorder;
		}

		private IEnumerator Timer()
		{
			while (true)
			{
				foreach (var item in activeBonuses)
					item.UpdateTime();

				RemoveBonuses();

				yield return new WaitForSeconds(1);
			}

		}

		private void RemoveBonuses()
		{
			foreach (var item in bonusIndexToRemove)
				activeBonuses.Remove(activeBonuses[item]);

			bonusIndexToRemove.Clear();
		}

		public Vector2 BallSpawnPosition()
		{
			float xCoordinate = transform.position.x + Random.Range(-ballSpawnRange, ballSpawnRange);
			return new Vector2(xCoordinate, transform.position.y + abovePlatformElevation);
		}

		#region VISIT
		public void Visit(PlatformSizeBonus visitor, bool isActivated)
		{
			float xSize;

			if (isActivated)
			{
				xSize = spriteRenderer.size.x * visitor.SizeModifier;
				activeBonuses.Add(visitor);
			}
			else
			{
				xSize = spriteRenderer.size.x / visitor.SizeModifier;
				bonusIndexToRemove.Add(activeBonuses.Count - 1);
			}

			spriteRenderer.size = new Vector2(xSize, spriteRenderer.size.y);
			collider.size = new Vector2(xSize, collider.size.y);


			CalculateBorders();
		}
		
		public void Visit(BallCountBonus visitor)
		{
			gameManager.IncreaseBallCount(visitor.BallIncrease);
		}
		#endregion
	}
}