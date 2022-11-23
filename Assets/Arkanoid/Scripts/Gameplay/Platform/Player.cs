using Arkanoid.Gameplay.Bonuses;
using Arkanoid.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid.Gameplay.Platform
{
	public class Player : MonoBehaviour, IBonusVisitor
	{
		#region FIELDS
		private List<BaseBonus> activeBonuses;
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

			StartCoroutine(Test());

			CalculateBorders();
		}

		private void CalculateBorders()
		{
			float platformBorder = mainCamera.ScreenToWorldPoint(new Vector2(mainCamera.pixelWidth, transform.position.y)).x;
			platformBorder -= collider.bounds.size.x / 2;
			playerMovement.PlatformBorders = platformBorder;
		}


		public void Visit(PlatformSizeBonus visitor)
		{
			spriteRenderer.size = new Vector2(spriteRenderer.size.x * visitor.SizeModifier, spriteRenderer.size.y);
			collider.size = new Vector2(collider.size.x * visitor.SizeModifier, collider.size.y);
			CalculateBorders();
		}

		private IEnumerator Test()
		{
			while (true)
			{
				for(int i = 0; i < collider.size.x; i++)
				yield return new WaitForSeconds(1);
			}

		}
	}
}