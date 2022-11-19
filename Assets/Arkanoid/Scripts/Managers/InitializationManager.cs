using Arkanoid.Data;
using Arkanoid.Models;
using Arkanoid.UI.Presenter;
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
		[Inject] LoadScenePresenter loadScenePresenter;
		#endregion

		private void Start()
		{
			Application.targetFrameRate = 60;
			settingsModel.InitializeSettings(dataModel.LoadData<SettingsSaveData>());
			loadScenePresenter.LoadMainMenu();
		}
	}
}

