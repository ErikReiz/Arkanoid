using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid.Additions
{
	[RequireComponent(typeof(EdgeCollider2D))]
	public class WallsGenerator : MonoBehaviour
	{
		#region CONST
		private readonly float cornerModifier = 0.3f;
		#endregion

		#region FIELDS
		private Vector3 borders;
		#endregion

		private void Awake()
		{
			Camera mainCamera = Camera.main;
			borders = mainCamera.ScreenToWorldPoint(new Vector3Int(mainCamera.pixelWidth, mainCamera.pixelHeight, 0));
			CreateBarrier();
		}

		private void CreateBarrier()
		{
			EdgeCollider2D wallsCollider = gameObject.GetComponent<EdgeCollider2D>();
			Vector2[] colliderPoints = new Vector2[6];

			colliderPoints[0] = new Vector2(-borders.x, -borders.y);
			colliderPoints[1] = new Vector2(-borders.x, borders.y - cornerModifier);
			colliderPoints[2] = new Vector2(-borders.x + cornerModifier, borders.y);
			colliderPoints[3] = new Vector2(borders.x - cornerModifier, borders.y);
			colliderPoints[4] = new Vector2(borders.x, borders.y - cornerModifier);
			colliderPoints[5] = new Vector2(borders.x, -borders.y);

			wallsCollider.points = colliderPoints;
		}
	}
}
