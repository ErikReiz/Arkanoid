using Arkanoid.Data;
using Arkanoid.Models;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Arkanoid.Managers
{
	public class InitializationManager : MonoBehaviour
	{
		#region FIELDS
		[Inject] GameSettingsModel settingsModel;
		[Inject] SaveDataModel dataModel;
		#endregion

		private void Start()
		{
			Application.targetFrameRate = 60;
			settingsModel.InitializeSettings(dataModel.LoadData<SettingsSaveData>());
			//TODO заменит
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}

