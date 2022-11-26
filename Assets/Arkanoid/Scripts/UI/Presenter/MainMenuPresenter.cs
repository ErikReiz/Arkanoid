using Arkanoid.Interfaces;
using Zenject;

namespace Arkanoid.UI.Presenter
{
	public class MainMenuPresenter : BasePresenter
	{
		#region FIELDS
		[Inject] private SettingsPresenter settingsPresenter;
		[Inject] private ScenesMenuPresenter scenesMenuPresenter;
		[Inject] private IView menuView;
		#endregion

		public void Play()
		{
			scenesMenuPresenter.Run();
		}

		public void OpenSettings()
		{
			settingsPresenter.Run();
		}

		public void Quit()
		{
			UnityEngine.Application.Quit();
		}

		public override void Run()
		{
			menuView.Show();
		}
	}
}