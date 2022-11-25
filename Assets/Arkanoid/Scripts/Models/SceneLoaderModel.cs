using Arkanoid.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid.Models
{
	public class SceneLoaderModel
	{
		#region CONST

		#endregion

		#region FIELDS
		private InGameConfig config;
		#endregion

		public SceneLoaderModel(InGameConfig config)
		{
			this.config = config;
		}

		public AsyncOperation LoadMainMenu()
		{
			return SceneManager.LoadSceneAsync(config.MainMenu);
		}

		public AsyncOperation LoadScene(int index)
		{
			try
			{
				return SceneManager.LoadSceneAsync(config.GetGameplaySceneIndex(index));
			}
			catch
			{
				return LoadMainMenu();
			}
		}

		public AsyncOperation LoadNextScene()
		{
			try
			{
				int nextSceneIndex = config.GetGameplaySceneIndex(SceneManager.GetActiveScene().buildIndex + 1);
				return SceneManager.LoadSceneAsync(nextSceneIndex);
			}
			catch
			{
				return LoadMainMenu();
			}
		}

		public AsyncOperation ReloadScene()
		{
			return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
		}
	}
}