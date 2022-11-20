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
		private MainConfig config;
		#endregion

		public SceneLoaderModel(MainConfig config)
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
	}
}