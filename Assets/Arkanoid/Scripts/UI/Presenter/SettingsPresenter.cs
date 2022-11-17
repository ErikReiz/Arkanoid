using Arkanoid.Interfaces;
using Arkanoid.Models;
using Zenject;

namespace Arkanoid.UI.Presenter
{
    public class SettingsPresenter : BasePresenter
    {
		#region FIELDS
		[Inject] private MenuPresenter menuPresenter;

		private ISettingsView settingsView;
		private GameSettingsModel gameSettingsModel;
		private SaveDataModel saveDataModel;
		#endregion

		public SettingsPresenter(ISettingsView view, GameSettingsModel gameSettingsModel, SaveDataModel saveDataModel)
		{
			settingsView = view;
			this.gameSettingsModel = gameSettingsModel;
			this.saveDataModel = saveDataModel;

			settingsView.OnBackButtonClicked += BackToMenu;
			settingsView.OnApplyButtonClicked += ApplySettings;
			settingsView.OnResolutionScaleChanged += ChangeResolutionScale;
			settingsView.OnSFXVolumeChanged += ChangeSFXVolume;
			settingsView.OnMusicVolumeChanged += ChangeMusicVolume;
		}

		private void BackToMenu()
		{
			menuPresenter.Run();
		}

		private void ApplySettings()
        {
			gameSettingsModel.ApplySettings();
			saveDataModel.SaveData(gameSettingsModel.Settings);
        }

		private void ChangeResolutionScale(float scale)
		{
			gameSettingsModel.ChangeResolutionScale(scale);
		}

		private void ChangeSFXVolume(bool isOn)
		{
			gameSettingsModel.ChangeSFXVolume(isOn);
		}

		private void ChangeMusicVolume(bool isOn)
		{
			gameSettingsModel.ChangeMusicVolume(isOn);
		}

		public override void Run()
		{
			settingsView.UpdateSettings(ref gameSettingsModel.Settings);
			settingsView.Show();
		}
    }
}