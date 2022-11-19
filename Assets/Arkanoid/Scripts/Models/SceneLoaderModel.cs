using Arkanoid.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid.Models
{
	public class SceneLoaderModel
	{
		#region FIELDS
		private ScenesData scenesData;
		private int currentSceneIndex = 0;
		#endregion

		public SceneLoaderModel(ScenesData scenesData)
		{
			this.scenesData = scenesData;
		}

		public AsyncOperation LoadMainMenu()
		{
			currentSceneIndex = 0;
			string scene = scenesData.MainMenu.name;
			return SceneManager.LoadSceneAsync(scene);
		}

		public AsyncOperation LoadScene(int index)
		{
			try
			{
				currentSceneIndex = Mathf.Abs(index) % scenesData.Scenes.Length;

				string scene = scenesData.Scenes[currentSceneIndex - 1].name;
				return SceneManager.LoadSceneAsync(scene);
			}
			catch
			{
				return LoadMainMenu();
			}

		}
	}
}