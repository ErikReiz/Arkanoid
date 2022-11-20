using UnityEngine;
using Zenject;

namespace Arkanoid.Platform
{
	public class BallMovement : MonoBehaviour
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private float speed = 5f;
		#endregion

		#region FIELDS
		private Vector3 movementDirection = new(0.3f, 1, 0);
		#endregion

		private void FixedUpdate()
		{
			transform.position += movementDirection * speed * Time.fixedDeltaTime;
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			movementDirection = Vector3.Reflect(movementDirection, collision.contacts[0].normal);
		}
	}
}