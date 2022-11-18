using Arkanoid.Data;
using Arkanoid.Interfaces;
using Zenject;

namespace Arkanoid.UI.Presenter
{
    public class ScenesMenuPresenter : BasePresenter
    {
		#region FIELDS
		[Inject] private MenuPresenter menuPresenter;
		[Inject] private LoadScenePresenter loadScenePresenter;

		private IScenesMenuView scenesMenuView;
		private ScenesData scenesData;
		#endregion

		public ScenesMenuPresenter(IScenesMenuView view, ScenesData scenesData)
		{
			scenesMenuView = view;
			this.scenesData = scenesData;

			scenesMenuView.OnBackButtonClicked += Back;
			scenesMenuView.OnSceneButtonClicked += OnSceneChosen;
		}

		private void Back()
		{
			menuPresenter.Run();
		}

		private void OnSceneChosen(int sceneIndex)
		{
			loadScenePresenter.LoadScene(sceneIndex);
		}

		public override void Run()
		{
			scenesMenuView.UpdateScenesList(scenesData.Scenes.Length);
			scenesMenuView.Show();
		}
	}
}