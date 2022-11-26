using UnityEngine;

namespace Arkanoid.Additions
{
	[RequireComponent(typeof(EdgeCollider2D))]
	public class DestroyBarrier : MonoBehaviour
	{
		private void Awake()
		{
			CreateBarrier();
		}

		private void CreateBarrier()
		{
			EdgeCollider2D collider = GetComponent<EdgeCollider2D>();
			collider.isTrigger = true;

			Camera mainCamera = Camera.main;
			Vector3 borders = mainCamera.ScreenToWorldPoint(new Vector3Int(mainCamera.pixelWidth, mainCamera.pixelHeight, 0));

			Vector2[] colliderPoints = new Vector2[2];
			colliderPoints[0] = new Vector2(borders.x, -borders.y);
			colliderPoints[1] = new Vector2(-borders.x, -borders.y);
			collider.points = colliderPoints;
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			Destroy(collision.gameObject);
		}
	}
}