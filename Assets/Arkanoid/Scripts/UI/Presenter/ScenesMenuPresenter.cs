using Arkanoid.Data;
using Arkanoid.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Arkanoid.UI.Presenter
{
    public class ScenesMenuPresenter : BasePresenter
    {
		#region FIELDS
		[Inject] private MenuPresenter menuPresenter;

		private IScenesMenuView scenesMenuView;
		private ScenesData scenesData;
		#endregion

		public ScenesMenuPresenter(IScenesMenuView view, ScenesData scenesData)
		{
			scenesMenuView = view;
			this.scenesData = scenesData;

			scenesMenuView.OnBackButtonClicked += Back;
		}

		private void Back()
		{
			menuPresenter.Run();
		}

		public override void Run()
		{
			scenesMenuView.UpdateScenesList(scenesData.Scenes.Length);
			scenesMenuView.Show();
		}
	}
}