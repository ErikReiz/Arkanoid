using Arkanoid.Interfaces;
using Arkanoid.UI.Presenter;
using DG.Tweening;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

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
		[SerializeField] private Transform tweeningObject;
		#endregion

		#region PROPERTIES
		[Inject] LoadPresenter loadPresenter;
		#endregion

		private IEnumerator Loading()
		{
			while(loadPresenter. <= 1)
			{
				loadingBar.value = LoadingOperation.progress;
				yield return new WaitForEndOfFrame();
			}
		}

		public Task Show()
		{
			canvas.gameObject.SetActive(true);
			return tweeningObject.DOScale(new Vector3(1, 1), tweeningLength).AsyncWaitForCompletion();
		}

		public Task Hide()
		{
			Task task = tweeningObject.DOScale(Vector3.zero, tweeningLength).AsyncWaitForCompletion();
			canvas.gameObject.SetActive(false);
			return task;
		}

		public void StartLoading()
		{
			StartCoroutine(Loading());
		}
	}
}