using Arkanoid.Gameplay.Platform;
using Arkanoid.Interfaces;
using Arkanoid.Managers;
using Arkanoid.Patterns.Factories;
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
		[SerializeField] private PauseMenuView pauseView;
		[SerializeField] private ScoreMenuView scoreView;

		[Header("Gameplay")]
		[SerializeField] private Player player;
		#endregion

		public override void InstallBindings()
        {
			#region VIEW
			Container.Bind<IHudView>().FromInstance(hudView).AsSingle();
			Container.Bind<IView>().FromInstance(pauseView).AsSingle();
			Container.Bind<IScoreMenuView>().FromInstance(scoreView).AsSingle();
			#endregion

			#region PRESENTER
			Container.Bind<HudPresenter>().ToSelf().AsSingle().NonLazy();
			Container.Bind<PauseMenuPresenter>().ToSelf().AsSingle().NonLazy();
			Container.Resolve<GameManager>().PauseMenuPresenter = Container.Resolve<PauseMenuPresenter>();
			#endregion

			#region GAMEPLAY
			Container.Bind<IBonusVisitor>().FromInstance(player).AsSingle();
			Container.Rebind<Player>().FromInstance(player).AsSingle();
			#endregion

			#region FACTORIES
			Container.Bind<IBonusFactory>().To<BonusFactory>().AsSingle();
			Container.Resolve<IBallFactory>().BindPlayer(player);
			#endregion
		}

		private void Awake()
		{
			base.Start();
			Container.Resolve<HudPresenter>().Run();
		}
	}
}