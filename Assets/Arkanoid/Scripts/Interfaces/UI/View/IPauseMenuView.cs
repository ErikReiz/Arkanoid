using UnityEngine.Events;

namespace Arkanoid.Interfaces
{
    public interface IPauseMenuView : IView
    {
        #region EVENTS
        public event UnityAction OnPlayButtonClicked;
        public event UnityAction OnQuitButtonClicked;
        #endregion
    }
}