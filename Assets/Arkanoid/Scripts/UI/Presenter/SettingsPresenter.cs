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
		#endregion

		public SettingsPresenter(ISettingsView view, GameSettingsModel gameSettings)
		{
			settingsView = view;
			gameSettingsModel = gameSettings;

			settingsView.OnBackButtonClicked += BackToMenu;
			settingsView.OnResolutionScaleChanged += ChangeResolutionScale;
			settingsView.OnSFXVolumeChanged += ChangeSFXVolume;
			settingsView.OnMusicVolumeChanged += ChangeMusicVolume;
		}

		private void BackToMenu()
		{
			menuPresenter.Run();
		}

		private void ChangeResolutionScale(float scale)
		{

		}

		private void ChangeSFXVolume(bool isTurnOn)
		{

		}

		private void ChangeMusicVolume(bool isTurnOn)
		{

		}

		public override void Run()
		{
			settingsView.Show();
		}
    }
}