using Arkanoid.Gameplay.Platform;
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
		[Header("UI")]
		[SerializeField] private HudView hudView;

		[Header("Gaemplay")]
		[SerializeField] private Player player;
		#endregion

		public override void InstallBindings()
        {
			#region VIEW
			Container.Bind<IHudView>().FromInstance(hudView).AsSingle();
			#endregion

			#region PRESENTER
			Container.Bind<HudPresenter>().ToSelf().AsSingle().NonLazy();
			#endregion

			#region GAMEPLAY
			Container.Bind<IBonusVisitor>().FromInstance(player).AsSingle();
			#endregion
		}

		private void Awake()
		{
			base.Start();
			Container.Resolve<HudPresenter>().Run();
		}
	}
}