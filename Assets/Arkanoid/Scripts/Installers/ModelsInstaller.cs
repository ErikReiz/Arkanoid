using Arkanoid.Data;
using Arkanoid.Interfaces;
using Arkanoid.Models;
using Arkanoid.Patterns.Factories;
using Unity.RemoteConfig;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace Arkanoid.Installers
{
    public class ModelsInstaller : MonoInstaller
    {
        #region SERIALIZABLE FIELDS
        [SerializeField] private InGameConfig config;
		[SerializeField] private RemoteConfig remoteConfig;
        [SerializeField] private AudioMixer audioMixer;
        #endregion

        public override void InstallBindings()
        {
            #region MODELS
            Container.Bind<PauseModel>().ToSelf().AsSingle();
            Container.Bind<GameSettingsModel>().ToSelf().AsSingle();
            Container.Bind<SaveDataModel>().ToSelf().AsSingle();
            Container.Bind<SceneLoaderModel>().ToSelf().AsSingle();
            Container.Bind<ISerializationHelper>().To<XMLSerializationHelper>().AsSingle();
            #endregion

            #region FACTORIES
            Container.Bind<IBallFactory>().To<BallFactory>().AsSingle();
			#endregion

			#region CONFIGS
			Container.Bind<InGameConfig>().FromScriptableObject(config).AsSingle();

            ConfigManager.FetchCompleted += t =>
            {
                Container.Bind<RemoteConfig>().FromNew().AsSingle();
            }; 
            #endregion

            #region OTHER
            Container.Bind<AudioMixer>().FromInstance(audioMixer).AsSingle();
            #endregion
        }
    }
}
