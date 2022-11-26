using UnityEngine.Events;

namespace Arkanoid.Interfaces
{
    public interface IMenuView : IView
    {
        #region EVENTS
        public event UnityAction OnPlayButtonClicked;
        public event UnityAction OnSettingsButtonClicked;
        public event UnityAction OnQuitButtonClicked;
        #endregion
    }
}