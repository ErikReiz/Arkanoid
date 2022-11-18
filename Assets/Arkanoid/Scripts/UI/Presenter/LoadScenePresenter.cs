using Arkanoid.Interfaces;
using Arkanoid.Models;
using UnityEngine;

namespace Arkanoid.UI.Presenter
{
	public class LoadScenePresenter
	{
		#region FIELDS
		ILoadingView loadingView;
		SceneLoaderModel sceneLoaderModel;
		#endregion

		public LoadScenePresenter(ILoadingView loadingView, SceneLoaderModel sceneLoaderModel)
		{
			this.loadingView = loadingView;
			this.sceneLoaderModel = sceneLoaderModel;
		}

		private async void Loading(System.Func<AsyncOperation> loadAction)
		{
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