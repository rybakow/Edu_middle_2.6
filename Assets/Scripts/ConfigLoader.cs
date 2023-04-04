using UnityEngine;

namespace DefaultNamespace
{
    public class ConfigLoader : IConfigLoader
    {
        private Settings _gameConfig;

        public void LoadConfig()
        {
            _gameConfig = ScriptableObject.CreateInstance<Settings>();
            _gameConfig = Resources.Load<Settings>("PlayerSettings");
        }

        public Settings GetGameConfig()
        {
            LoadConfig();
            return _gameConfig;
        }
    }

    public interface IConfigLoader
    {
        void LoadConfig();
        Settings GetGameConfig();
    }

}