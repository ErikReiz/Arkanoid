using Arkanoid.Interfaces;
using Arkanoid.UI.Presenter;
using Arkanoid.UI.View;
using UnityEngine;
using Zenject;

namespace Arkanoid.Installers
{
    public class GameplaySceneInstaller : MonoInstaller
    {
		#region SERIALIZABLE FIELDS
		[SerializeField] private HudView hudView;
		#endregion

		public override void InstallBindings()
        {
			#region VIEW
			Container.Bind<IHudView>().FromInstance(hudView).AsSingle();
			#endregion

			#region PRESENTER
			Container.Bind<HudPresenter>().ToSelf().AsSingle().NonLazy();
			#endregion
		}

		private void Awake()
		{
			base.Start();
			Container.Resolve<HudPresenter>().Run();
		}
	}
}