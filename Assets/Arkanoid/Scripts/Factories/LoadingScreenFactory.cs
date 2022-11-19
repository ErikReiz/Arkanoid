using Arkanoid.Interfaces;
using Arkanoid.UI.View;
using UnityEngine;

namespace Arkanoid.Patterns.Factories
{
	public class LoadingScreenFactory : ILoadingScreenFactory
	{
		#region FIELDS
		private LoadingView loadingView;
		private LoadingView view;
		#endregion

		public LoadingScreenFactory(LoadingView loadingView)
		{
			this.loadingView = loadingView;
		}

		public ILoadingView Create()
		{
			view = GameObject.Instantiate<LoadingView>(loadingView);
			return view;
		}

		public void Unload()
		{
			GameObject.Destroy(view.gameObject);
		}
	}
}