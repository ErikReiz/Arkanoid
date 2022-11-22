using Arkanoid.Interfaces;
using Arkanoid.Models;
using UnityEngine;

namespace Arkanoid.UI.Presenter
{
	public class LoadPresenter
	{
		#region PROPERTIES
		public float TotalLoadingProgress { get { return }}
		#endregion

		#region FIELDS
		private ILoadingView loadingView;
		private ILoadingScreenFactory loadingScreenFactory;
		private SceneLoaderModel sceneLoaderModel;

		private AsyncOperation loadingSceneOperation;
		#endregion

		public LoadPresenter(ILoadingScreenFactory loadingScreenFactory, SceneLoaderModel sceneLoaderModel)
		{
			this.loadingScreenFactory = loadingScreenFactory;
			this.sceneLoaderModel = sceneLoaderModel;
		}

		private async void Loading(System.Func<AsyncOperation> loadAction)
		{
			loadingView = loadingScreenFactory.Create();
			await loadingView.Show();

			loadingSceneOperation = loadAction.Invoke();
			loadingView.StartLoading();
		}

		public void LoadMainMenu()
		{
			Loading(sceneLoaderModel.LoadMainMenu);
		}

		public void LoadScene(int sceneIndex)
		{
			Loading(() => sceneLoaderModel.LoadScene(sceneIndex));
		}
	}
}