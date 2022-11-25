namespace Arkanoid.Interfaces
{
    public interface IScoreMenuView : IView
    {
        #region METHODS
        public void UpdateScore(int score);
        #endregion
    }
}