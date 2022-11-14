using UnityEngine.Events;

namespace Arkanoid.Interfaces
{
    public interface ISettingsView : IView
    {
		#region EVENTS
		public event UnityAction OnBackButtonClicked;
		public event UnityAction<float> OnResolutionScaleChanged;
        public event UnityAction<bool> OnSoundVolumeChanged;
        public event UnityAction<bool> OnMusicVolumeChanged;
		#endregion
	}
}