using UnityEngine;

namespace DefaultNamespace
{
    public class ConfigLoader : IConfigLoader
    {
        private Settings _gameConfig;

        public ConfigLoader()
        {
            LoadConfig();
        }

        public void LoadConfig()
        {
            _gameConfig = new Settings();
            _gameConfig.Health = 500;
        }

        public Settings GetGameConfig()
        {
            return _gameConfig;
        }
    }

    public interface IConfigLoader
    {
        void LoadConfig();
        Settings GetGameConfig();
    }

}