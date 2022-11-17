using Arkanoid.Interfaces;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Arkanoid.UI.View
{
	public class ScenesMenuView : MonoBehaviour, IScenesMenuView
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private Canvas canvas;

		[Header("Buttons")]
		[SerializeField] private Button backButton;

		[Header("Grid")]
		[SerializeField] private GameObject sceneButton;
		[SerializeField] private Transform gridGroup;

		[Header("Tweening")]
		[SerializeField] private float tweeningLength = 0.3f;
		[SerializeField] private int hideDeltaChange = 1000;
		#endregion

		#region FIELDS
		private bool isInitialized = false;

		public event UnityAction OnBackButtonClicked;
		#endregion

		private void OnEnable()
		{
			backButton.onClick.AddListener(BackButtonClicked);
		}

		private void OnDisable()
		{
			backButton.onClick.RemoveListener(BackButtonClicked);
		}

		private async void BackButtonClicked()
		{
			await Hide();
			canvas.gameObject.SetActive(false);
			OnBackButtonClicked.Invoke();
		}

		public Task Show()
		{
			canvas.gameObject.SetActive(true);
			return transform.DOLocalMoveX(0, tweeningLength).AsyncWaitForCompletion();
		}

		public Task Hide()
		{
			return transform.DOLocalMoveX(hideDeltaChange, tweeningLength).AsyncWaitForCompletion();
		}

		public void UpdateScenesList(int scenesCount)
		{
			if(isInitialized)
				return;

			Debug.Log(scenesCount);
			isInitialized = true;
			for(int i = 0; i < scenesCount; i++)
			{
				Instantiate(sceneButton, gridGroup);
			}
		}
	}
}