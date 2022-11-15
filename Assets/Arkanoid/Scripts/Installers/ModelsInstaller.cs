using Arkanoid.Models;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace Arkanoid.Installers
{
    public class ModelsInstaller : MonoInstaller
    {
        #region SERIALIZABLE FIELDS
        [SerializeField] private AudioMixer audioMixer;
        #endregion

        public override void InstallBindings()
        {
            #region MODELS
            Container.Bind<GameSettingsModel>().ToSelf().AsSingle();
            #endregion

            #region OTHER
            Container.Bind<AudioMixer>().FromInstance(audioMixer).AsSingle();
            #endregion
        }
    }
}
