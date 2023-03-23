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
    
    private int _health;
    public Text healthValueTextUI;

    private PlayerStat _playerStat;
    
    public int Health
    {
        get => _health;
        set
        {
            _health = value;
            SaveStatistic();
        }
    }

    private void Start()
    {
        _playerStat = new PlayerStat();
        
        Health = settings.Health;
        GameManager.Health = Health;
    }

    private void Update()
    {
        healthValueTextUI.text = GameManager.Health.ToString();
    }
    
    private void SaveStatistic()
    {
        _playerStat.Health = GameManager.Health;
        _playerStat.FirstAidCount = GameManager.FirstAidCount;
        
        var jsonStr = JsonUtility.ToJson(_playerStat);
        
    }
}
