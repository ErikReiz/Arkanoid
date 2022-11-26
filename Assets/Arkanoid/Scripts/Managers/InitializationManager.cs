using Arkanoid.Data;
using Arkanoid.Models;
using Arkanoid.UI.Presenter;
using Unity.RemoteConfig;
using UnityEngine;
using Zenject;

namespace Arkanoid.Managers
{
	public class InitializationManager : MonoBehaviour
	{
		private struct UserAttributes { };
		private struct AppAttributes { };

		#region FIELDS
		[Inject] private GameSettingsModel settingsModel;
		[Inject] private SaveDataModel dataModel;
		[Inject] private LoadPresenter loadScenePresenter;
		#endregion

		private void Start()
		{
			Application.targetFrameRate = 60;
			settingsModel.InitializeSettings(dataModel.LoadData<SettingsSaveData>());
			LoadConfig();

			loadScenePresenter.LoadMainMenu();
		}

		private void LoadConfig()
		{
			ConfigManager.FetchConfigs<UserAttributes, AppAttributes>(new UserAttributes(), new AppAttributes());
		}
	}
}

