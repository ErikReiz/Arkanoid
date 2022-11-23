using Arkanoid.Interfaces;
using Arkanoid.Patterns.Factories;
using Arkanoid.UI.Presenter;
using Arkanoid.UI.View;
using UnityEngine;
using Zenject;

namespace Arkanoid.Installers
{
    public class LoadingInstaller : MonoInstaller
    {
        #region SERIALIZABLE FIELDS
        [SerializeField] private LoadingView loadingView;
        #endregion

        public override void InstallBindings()
        {
			#region LOADING
			Container.Bind<LoadingView>().FromInstance(loadingView).AsSingle();
            Container.Bind<LoadPresenter>().ToSelf().AsSingle();
            Container.Bind<ILoadingScreenFactory>().To<LoadingScreenFactory>().AsSingle();
			#endregion
        }
	}
}