using Arkanoid.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Arkanoid.Gameplay.Platform
{
	public class PlayerMovement : MonoBehaviour
	{
		#region PROPERTIES
		public float PlatformBorders { set { platformBorder = value; } }
		#endregion

		#region FIELDS
		[Inject] private PauseModel pauseModel;

		private Camera mainCamera;
		private Vector2 inputVector;
		private float platformBorder = 2f;
		#endregion

		private void Awake()
		{
			mainCamera = Camera.main;
		}

		private void Update()
		{
			Move();
		}

		private void Move()
		{
			Vector2 newPosition = new Vector2(inputVector.x, transform.position.y);
			transform.position = newPosition;
		}

		public void OnMove(InputAction.CallbackContext context)
		{
			if (pauseModel.IsPaused)
				return;

			inputVector = mainCamera.ScreenToWorldPoint(context.ReadValue<Vector2>());
			inputVector.x = Mathf.Clamp(inputVector.x, -platformBorder, platformBorder);
		}
	}
}

