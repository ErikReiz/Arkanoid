using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Arkanoid.Platform
{
	public class PlayerMovement : MonoBehaviour
	{
		#region CONST
		private float platformBorder = 2f;
		#endregion

		#region FIELDS
		private Camera mainCamera;
		private Vector2 inputVector;
		#endregion

		private void Awake()
		{
			mainCamera = Camera.main;
			CalculateScreenBorders();
		}

		private void Update()
		{
			Move();
		}

		private void CalculateScreenBorders()
		{
			platformBorder = mainCamera.ScreenToWorldPoint(new Vector2(mainCamera.pixelWidth, transform.position.y)).x;
			Collider2D collider = GetComponent<Collider2D>();
			platformBorder -= collider.bounds.size.x / 2;
		}

		private void Move()
		{
			Vector2 newPosition = new Vector2(inputVector.x, transform.position.y);
			transform.position = newPosition;
		}

		public void OnMove(InputAction.CallbackContext context)
		{
			inputVector = mainCamera.ScreenToWorldPoint(context.ReadValue<Vector2>());
			inputVector.x = Mathf.Clamp(inputVector.x, -platformBorder, platformBorder);
		}
	}
}

