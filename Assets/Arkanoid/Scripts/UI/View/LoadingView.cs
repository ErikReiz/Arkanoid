using Arkanoid.Interfaces;
using DG.Tweening;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid.UI.View
{
    public class LoadingView : MonoBehaviour, ILoadingView
    {
		#region SERIALIZABLE FIELDS
		[SerializeField] private Canvas canvas;		

		[Header("Slider")]
		[SerializeField] private Slider loadingBar;

		[Header("Tweening")]
		[SerializeField] private float tweeningLength = 0.3f;
		#endregion

		#region PROPERTIES
		public AsyncOperation LoadingOperation { private get; set; }
		#endregion

		private IEnumerator Loading()
		{
			if (LoadingOperation == null)
				StopCoroutine(Loading());

			while(LoadingOperation.progress <= 1)
			{
				loadingBar.value = LoadingOperation.progress;
				yield return new WaitForEndOfFrame();
			}
		}

		public Task Show()
		{
			canvas.gameObject.SetActive(true);
			return transform.DOScale(new Vector3(1, 1), tweeningLength).AsyncWaitForCompletion();
		}

		public Task Hide()
		{
			Task task = transform.DOScale(Vector3.zero, tweeningLength).AsyncWaitForCompletion();
			canvas.gameObject.SetActive(false);
			return task;
		}

		public void StartLoading(AsyncOperation loadingOperation)
		{
			LoadingOperation = loadingOperation;
			StartCoroutine(Loading());
		}
	}
}