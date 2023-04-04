using DefaultNamespace;
using UnityEngine;
using Zenject;

public class CharacterHealth : MonoBehaviour
{
    [Inject] private IConfigLoader _configLoader;
    
    public int Health
    {
        get => GameManager.Health;
        set => GameManager.Health = value;
    }
    
    public int FirstAid
    {
        get => GameManager.FirstAidCount;
        set => GameManager.FirstAidCount = value;
    }

    private void Start()
    {
        var gameConfig = _configLoader.GetGameConfig();

        Health = gameConfig.Health;
    }
    
}
