using Arkanoid.Data;
using Arkanoid.Interfaces;
using Zenject;

namespace Arkanoid.UI.Presenter
{
    public class ScenesMenuPresenter : BasePresenter
    {
		#region FIELDS
		[Inject] private MainMenuPresenter menuPresenter;
		[Inject] private LoadPresenter loadScenePresenter;
		[Inject] private IScenesMenuView scenesMenuView;

		private InGameConfig config;
		#endregion

		public ScenesMenuPresenter(InGameConfig config)
		{
			this.config = config;
		}

		public void Back()
		{
			menuPresenter.Run();
		}

		public void OnSceneChosen(int sceneIndex)
		{
			loadScenePresenter.LoadScene(sceneIndex);
		}

		public override void Run()
		{
			scenesMenuView.UpdateScenesList(config.GameplayScenesCount);
			scenesMenuView.Show();
		}
	}
}