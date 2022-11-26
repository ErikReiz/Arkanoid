using Arkanoid.Managers;
using UnityEngine;
using Zenject;

namespace Arkanoid.Installers
{
	public class ManagerInstallers : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<GameManager>().ToSelf().AsSingle();
		}
	}
}

