using Arkanoid.Interfaces;
using Arkanoid.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid.UI.Presenter
{
	public class HudPresenter : BasePresenter
	{
		#region FIELDS
		private IHudView hudView;
		private PauseModel pauseModel;
		#endregion

		public HudPresenter(IHudView hudView, PauseModel pauseModel)
		{
			this.hudView = hudView;
			this.pauseModel = pauseModel;

			hudView.OnPauseButtonClicked += PauseGame;
		}

		private void PauseGame()
		{
			pauseModel.PauseGame(true);
		}

		public override void Run()
		{
			hudView.Show();
		}
	}
}