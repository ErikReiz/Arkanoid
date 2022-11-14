using Arkanoid.Interfaces;
using Zenject;

namespace Arkanoid.UI.Presenter
{
    public class SettingsPresenter : BasePresenter
    {
		#region FIELDS
		[Inject] private MenuPresenter menuPresenter;
		private ISettingsView settingsView;
		#endregion

		public SettingsPresenter(ISettingsView view)
		{
			settingsView = view;

			settingsView.OnBackButtonClicked += BackToMenu;
			settingsView.OnResolutionScaleChanged += ChangeResolutionScale;
			settingsView.OnSoundVolumeChanged += ChangeSoundVolume;
			settingsView.OnMusicVolumeChanged += ChangeMusicVolume;
		}

		private void BackToMenu()
		{
			menuPresenter.Run();
		}

		private void ChangeResolutionScale(float scale)
		{

		}

		private void ChangeSoundVolume(bool isTurnOn)
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