using Unity.RemoteConfig;
using UnityEngine;

namespace Arkanoid.Data
{ 
    public class DataConfig
    {
        [System.Serializable]
        private struct Test
        {
            public float bonusFallSpeed;
        }

        private Test test;

        public DataConfig()
        {
            Debug.Log("dsd");
            string json = ConfigManager.appConfig.GetJson("Game settings");
            JsonUtility.FromJsonOverwrite(json, test.bonusFallSpeed);

            Debug.Log(test.bonusFallSpeed);
        }
    }
}