using Arkanoid.Interfaces;
using Arkanoid.Patterns.Factories;
using Arkanoid.UI.View;
using UnityEngine;
using Zenject;

namespace Arkanoid.Installers
{
    public class FactoriesInstaller : MonoInstaller
    {
        #region SERIALIZABLE FIELDS
        [SerializeField] private LoadingView loadingView;
        #endregion

        public override void InstallBindings()
        {
            Container.Bind<LoadingView>().FromInstance(loadingView).AsSingle();
            Container.Bind<ILoadingScreenFactory>().To<LoadingScreenFactory>().AsSingle();
        }
	}
}