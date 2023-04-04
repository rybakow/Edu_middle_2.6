using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CharacterHealth : MonoBehaviour
{
    public int HealthView;
    
    [Inject] private IConfigLoader _configLoader;
    
    public int Health
    {
        get => GameManager.Health;
        set {
            GameManager.Health = value;
            HealthView = value;
        }
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
        FirstAid = 0;
    }
    
}
