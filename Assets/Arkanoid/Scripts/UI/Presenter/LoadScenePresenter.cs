using Arkanoid.Interfaces;
using Arkanoid.Models;
using UnityEngine;

namespace Arkanoid.UI.Presenter
{
	public class LoadScenePresenter
	{
		#region FIELDS
		private ILoadingView loadingView;
		private ILoadingScreenFactory loadingScreenFactory;
		private SceneLoaderModel sceneLoaderModel;
		#endregion

		public LoadScenePresenter(ILoadingScreenFactory loadingScreenFactory, SceneLoaderModel sceneLoaderModel)
		{
			this.loadingScreenFactory = loadingScreenFactory;
			this.sceneLoaderModel = sceneLoaderModel;
		}

		private async void Loading(System.Func<AsyncOperation> loadAction)
		{
			loadingView = loadingScreenFactory.Create();
			await loadingView.Show();
			loadingView.StartLoading(loadAction.Invoke());
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