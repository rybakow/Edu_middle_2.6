using UnityEngine;

namespace DefaultNamespace
{
    public class DummyConfigLoader : IConfigLoader
    {
        public void LoadConfig() { }

        public Settings GetGameConfig()
        {
            return new Settings
            {
                Health = 1000
            };
        }
    }

}