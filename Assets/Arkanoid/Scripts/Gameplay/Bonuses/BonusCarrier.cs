using Arkanoid.Data;
using Arkanoid.Models;
using UnityEngine;
using Zenject;

namespace Arkanoid.Gameplay.Bonuses
{
    public class BonusCarrier : MonoBehaviour
    {
		#region SERIALIZABLE FIELDS
		[SerializeField] private float speed = 3f;
		#endregion

		#region FIELDS
		[Inject] private PauseModel pauseModel;
		[Inject] private InGameConfig config;
		private BaseBonus bonus;
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

		public void Initialize(BaseBonus bonus)
		{
			this.bonus = bonus;
		}
	}
}