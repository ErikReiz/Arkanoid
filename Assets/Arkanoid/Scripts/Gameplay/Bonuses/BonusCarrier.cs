using Arkanoid.Data;
using Arkanoid.Models;
using UnityEngine;

namespace Arkanoid.Gameplay.Bonuses
{
    public class BonusCarrier : MonoBehaviour
    {
		#region FIELDS
		private PauseModel pauseModel;
		private InGameConfig config;
		private BaseBonus bonus;

		private float speed = 3f; // TODO заменить
		#endregion

		private void FixedUpdate()
		{
			if (pauseModel.IsPaused)
				return;

			transform.position += Vector3.down * speed * Time.fixedDeltaTime;
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			LayerMask collisionLayer = collision.gameObject.layer;

			if (((1 << collisionLayer) & config.PlayerLayer) != 0)
			{
				bonus.Activate();
				Destroy(gameObject);
			}
		}

		public void Initialize(PauseModel pauseModel, InGameConfig config, BaseBonus bonus)
		{
			this.pauseModel = pauseModel;
			this.config = config;
			this.bonus = bonus;
		}
	}
}