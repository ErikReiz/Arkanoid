using Arkanoid.Interfaces;
using Arkanoid.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Arkanoid.UI.Presenter
{
	public class HudPresenter : BasePresenter
	{
		#region FIELDS
		[Inject] private PauseMenuPresenter pauseMenuPresenter;

		private IHudView hudView;
		#endregion

		public HudPresenter(IHudView hudView)
		{
			this.hudView = hudView;

			hudView.OnPauseButtonClicked += PauseGame;
		}

		private void PauseGame()
		{
			pauseMenuPresenter.Run();
		}

		public override void Run()
		{
			hudView.Show();
		}
	}
}