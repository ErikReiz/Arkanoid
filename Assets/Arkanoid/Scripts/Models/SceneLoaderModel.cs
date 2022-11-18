using Arkanoid.Data;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid.Models
{
	public class SceneLoaderModel
	{
		#region FIELDS
		private ScenesData scenesData;
		private int currentSceneIndex = -1;
		#endregion

		public SceneLoaderModel(ScenesData scenesData)
		{
			this.scenesData = scenesData;
		}

		public AsyncOperation LoadMainMenu()
		{
			currentSceneIndex = -1;
			SceneAsset scene = scenesData.MainMenu;
			return SceneManager.LoadSceneAsync(scene.name);
		}

		public AsyncOperation LoadScene(int index)
		{
			try
			{
				currentSceneIndex = Mathf.Abs(index) % scenesData.Scenes.Length;

				SceneAsset scene = scenesData.Scenes[currentSceneIndex];
				return SceneManager.LoadSceneAsync(scene.name);
			}
			catch
			{
				return LoadMainMenu();
			}

		}
	}
}