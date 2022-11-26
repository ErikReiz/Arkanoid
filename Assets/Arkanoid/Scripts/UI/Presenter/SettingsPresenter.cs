using Arkanoid.Interfaces;
using Arkanoid.Models;
using Zenject;

namespace Arkanoid.UI.Presenter
{
    public class SettingsPresenter : BasePresenter
    {
		#region FIELDS
		[Inject] private MainMenuPresenter menuPresenter;
		[Inject] private ISettingsView settingsView;

		private GameSettingsModel gameSettingsModel;
		private SaveDataModel saveDataModel;
		#endregion

		public SettingsPresenter(GameSettingsModel gameSettingsModel, SaveDataModel saveDataModel)
		{
			this.gameSettingsModel = gameSettingsModel;
			this.saveDataModel = saveDataModel;
		}

		public void BackToMenu()
		{
			menuPresenter.Run();
		}

		public void ApplySettings()
        {
			gameSettingsModel.ApplySettings();
			saveDataModel.SaveData(gameSettingsModel.Settings);
        }

		public void ChangeResolutionScale(float scale)
		{
			gameSettingsModel.ChangeResolutionScale(scale);
		}

		public void ChangeSFXVolume(bool isOn)
		{
			gameSettingsModel.ChangeSFXVolume(isOn);
		}

		public void ChangeMusicVolume(bool isOn)
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