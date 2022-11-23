using Arkanoid.Interfaces;
using Arkanoid.Models;
using UnityEngine;

namespace Arkanoid.UI.Presenter
{
	public class LoadPresenter
	{
		#region PROPERTIES
		public float TotalLoadingProgress { get { return loadSceneOperation.progress; } }
		#endregion

		#region FIELDS
		private ILoadingView loadingView;
		private ILoadingScreenFactory loadingScreenFactory;
		private SceneLoaderModel sceneLoaderModel;

		private AsyncOperation loadSceneOperation;
		#endregion

		public LoadPresenter(ILoadingScreenFactory loadingScreenFactory, SceneLoaderModel sceneLoaderModel)
		{
			this.loadingScreenFactory = loadingScreenFactory;
			this.sceneLoaderModel = sceneLoaderModel;
		}

		private async void Loading(System.Func<AsyncOperation> loadAction)
		{
			loadingView = loadingScreenFactory.Create(this);
			await loadingView.Show();

			loadSceneOperation = loadAction.Invoke();
			loadingView.StartLoading();
		}

		public void LoadMainMenu()
		{
			if(loadSceneOperation?.isDone ?? true)
				Loading(sceneLoaderModel.LoadMainMenu);
		}

		public void LoadScene(int sceneIndex)
		{
			if (loadSceneOperation?.isDone ?? true)
				Loading(() => sceneLoaderModel.LoadScene(sceneIndex));
		}

		public void ReloadScene()
		{
			if (loadSceneOperation?.isDone ?? true)
				Loading(sceneLoaderModel.ReloadScene);
		}
	}
}