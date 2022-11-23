using Arkanoid.Managers;
using Arkanoid.Models;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Arkanoid.Gameplay.Platform
{
	public class Ball : MonoBehaviour
	{
		#region CONST
		private readonly float minimalDirection = 0.1f;
		private readonly float directionRange = 0.4f;
		#endregion

		#region SERIALIZABLE FIELDS
		[SerializeField] private float speed = 5f;
		[SerializeField] private float maxSpeed = 8f;
		[SerializeField] private float increaseFactor = 0.5f;
		[SerializeField] private float increaseDelay = 4f;
		#endregion

		#region FIELDS
		[Inject] private GameManager gameManager;
		[Inject] private PauseModel pauseModel;

		private Vector3 movementDirection;
		#endregion

		private void Start()
		{
			SetStartDirection();
			StartCoroutine(IncreaseSpeedCoorutine());
		}

		private void SetStartDirection()
		{
			float xDirection = Random.Range(minimalDirection, directionRange);
			if (Random.Range(0, 1) == 0)
				xDirection *= -1;

			movementDirection = new(xDirection, 1);
		}

		private IEnumerator IncreaseSpeedCoorutine()
		{
			while(speed < maxSpeed)
			{
				speed = Mathf.Clamp(speed + increaseFactor, speed, maxSpeed);
				yield return new WaitForSeconds(increaseDelay);
			}
		}

		private void FixedUpdate()
		{
			if (pauseModel.IsPaused)
				return;

			transform.position += movementDirection * speed * Time.fixedDeltaTime;
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			movementDirection = Vector3.Reflect(movementDirection, collision.contacts[0].normal);
		}

		private void OnDestroy()
		{
			gameManager.OnBallDestroyed();
		}
	}
}