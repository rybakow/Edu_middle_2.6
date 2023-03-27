using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public Settings settings;

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
        Health = settings.Health;
        FirstAid = 0;
    }
    
}
