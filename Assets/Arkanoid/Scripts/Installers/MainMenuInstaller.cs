using Arkanoid.Interfaces;
using Arkanoid.UI.Presenter;
using Arkanoid.UI.View;
using UnityEngine;
using Zenject;

namespace Arkanoid.Installers
{
	public class MainMenuInstaller : MonoInstaller
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private MainMenuView mainMenuView;
		[SerializeField] private SettingsView settingsView;
		[SerializeField] private ScenesMenuView scenesMenuView;
		#endregion

		public override void InstallBindings()
		{
			#region VIEW
			Container.Bind<IView>().FromInstance(mainMenuView).AsSingle();
			Container.Bind<ISettingsView>().FromInstance(settingsView).AsSingle();
			Container.Bind<IScenesMenuView>().FromInstance(scenesMenuView).AsSingle();
			#endregion

			#region PRESENTERS
			Container.Bind<MainMenuPresenter>().ToSelf().AsSingle().NonLazy();
			Container.Bind<SettingsPresenter>().ToSelf().AsSingle().NonLazy();
			Container.Bind<ScenesMenuPresenter>().ToSelf().AsSingle().NonLazy();
			#endregion
		}

		private void Awake()
		{
			base.Start();
			Container.Resolve<MainMenuPresenter>().Run();
		}
	}
}
