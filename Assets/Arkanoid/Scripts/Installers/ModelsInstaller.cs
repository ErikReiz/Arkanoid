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
        [SerializeField] private ScenesData levelsData;
        [SerializeField] private AudioMixer audioMixer;
        #endregion

        public override void InstallBindings()
        {
            #region MODELS
            Container.Bind<GameSettingsModel>().ToSelf().AsSingle();
            Container.Bind<SaveDataModel>().ToSelf().AsSingle();
            Container.Bind<SceneLoaderModel>().ToSelf().AsSingle();
            Container.Bind<ISerializationHelper>().To<XMLSerializationHelper>().AsSingle();
            #endregion
            Container.Bind<LoadScenePresenter>().ToSelf().AsSingle(); //TODO ��������

			#region DATA
			Container.Bind<ScenesData>().FromScriptableObject(levelsData).AsSingle();
			#endregion

			#region OTHER
            Container.Bind<AudioMixer>().FromInstance(audioMixer).AsSingle();
            #endregion
        }
    }
}
