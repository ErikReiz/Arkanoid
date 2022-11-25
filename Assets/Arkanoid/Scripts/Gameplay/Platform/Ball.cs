using Arkanoid.Managers;
using Arkanoid.Models;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Arkanoid.Gameplay.Platform
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class Ball : MonoBehaviour
	{
		#region CONST
		private readonly float minimalDirection = 0.1f;
		private readonly float directionRange = 0.4f;
		#endregion

		#region SERIALIZABLE FIELDS
		[SerializeField] private Rigidbody2D rigidbody;
		[SerializeField] private AnimationCurve bounceDotProductCurve;

		[SerializeField] private float speed = 5f;
		[SerializeField] private float maxSpeed = 8f;
		[SerializeField] private float increaseFactor = 0.5f;
		[SerializeField] private float increaseDelay = 4f;
		#endregion

		#region FIELDS
		[Inject] private GameManager gameManager;
		[Inject] private PauseModel pauseModel;

		private bool isQutting = false;
		private Vector3 movementDirection;
		#endregion

		private void Start()
		{
			SetStartDirection();
			StartCoroutine(IncreaseSpeedCoroutine());
		}

		private void SetStartDirection()
		{
			float xDirection = Random.Range(minimalDirection, directionRange);
			if (Random.Range(0, 2) == 0)
				xDirection *= -1;

			movementDirection = new Vector3(xDirection, 1).normalized;
		}

		private IEnumerator IncreaseSpeedCoroutine()
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

			rigidbody.MovePosition(transform.position + movementDirection * speed * Time.fixedDeltaTime);
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			ReflectDirection(collision.contacts[0].normal);
		}

		private void ReflectDirection(Vector3 normalVector)
		{
			float dotProduct = Vector2.Dot(normalVector, movementDirection);
			float dotProdutctMultiplier = bounceDotProductCurve.Evaluate(Mathf.Abs(dotProduct));

			dotProduct *= -dotProdutctMultiplier;

			movementDirection = new Vector3(dotProduct * normalVector.x + movementDirection.x, dotProduct * normalVector.y + movementDirection.y).normalized;
		}

		private void OnApplicationQuit()
		{
			isQutting = true;
		}

		private void OnDestroy()
		{
			if(!isQutting)
				gameManager.OnBallDestroyed();
		}
	}
}