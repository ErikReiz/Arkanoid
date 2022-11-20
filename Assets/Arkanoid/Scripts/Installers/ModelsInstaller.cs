using Arkanoid.Data;
using Arkanoid.Interfaces;
using Arkanoid.Models;
using Arkanoid.Patterns.Factories;
using Arkanoid.UI.Presenter;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace Arkanoid.Installers
{
    public class ModelsInstaller : MonoInstaller
    {
        #region SERIALIZABLE FIELDS
        [SerializeField] private MainConfig config;
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

            Container.Bind<LoadScenePresenter>().ToSelf().AsSingle(); //TODO заменить

			#region CONFIGS
			Container.Bind<MainConfig>().FromScriptableObject(config).AsSingle();
			#endregion

			#region OTHER
            Container.Bind<AudioMixer>().FromInstance(audioMixer).AsSingle();
            #endregion
        }
    }
}
