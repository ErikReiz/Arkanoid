using Arkanoid.Data;
using Arkanoid.Interfaces;
using Arkanoid.Models;
using UnityEngine;
using Zenject;

namespace Arkanoid.Gameplay.Bonuses
{
	public abstract class BaseBonus : MonoBehaviour
	{
		#region FIELDS
		[Inject] protected IBonusVisitor bonusVisitor;
		[Inject] private InGameConfig config;
		[Inject] private PauseModel pauseModel;

		private float speed = 5f; // TODO ��������
		#endregion

		private void FixedUpdate()
		{
			if (pauseModel.IsPaused)
				return;

			transform.position += Vector3.down * speed * Time.fixedDeltaTime;
		}

		protected void OnTriggerEnter2D(Collider2D collision)
		{
			LayerMask collisionLayer = collision.gameObject.layer;

			if (((1 << collisionLayer) & config.PlayerLayer) != 0)
			{
				Activate();
				Destroy(gameObject);
			}

		}

		public abstract void Activate();
	}
}