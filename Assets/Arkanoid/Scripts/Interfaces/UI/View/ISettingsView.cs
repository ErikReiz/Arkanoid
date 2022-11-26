using Arkanoid.Data;
using UnityEngine.Events;

namespace Arkanoid.Interfaces
{
    public interface ISettingsView : IView
    {
		#region METHODS
		public void UpdateSettings(ref SettingsSaveData settingsSaveData);
		#endregion
	}
}