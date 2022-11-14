using Arkanoid.Interfaces;
using Zenject;

namespace Arkanoid.UI.Presenter
{
	public class MenuPresenter : BasePresenter
	{
		#region FIELDS
		[Inject]private SettingsPresenter settingsPresenter;
		private IMenuView menuView;
		#endregion

		public MenuPresenter(IMenuView view)
		{
			menuView = view;

			menuView.OnPlayButtonClicked += Play;
			menuView.OnSettingsButtonClicked += OpenSettings;
			menuView.OnQuitButtonClicked += Quit;
		}

		public void Play()
		{
			
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