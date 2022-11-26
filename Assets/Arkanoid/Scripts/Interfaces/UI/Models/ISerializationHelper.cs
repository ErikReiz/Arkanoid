namespace Arkanoid.Interfaces
{
    public interface ISerializationHelper
    {
        #region METHODS
        public string Serialize<T>(T objectToSerialieze);
        public T Deserealize<T>(string objectToDeserialize);
        #endregion
    }
}

