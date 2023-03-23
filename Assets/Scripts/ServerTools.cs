using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using UnityGoogleDrive.Data;

public class ServerTools : MonoBehaviour
{
    private PlayerStat _playerStat;

    private File uploadedFile;

    private void Awake()
    {
        _playerStat = new PlayerStat();
    }

    public void SaveStats()
    {
        _playerStat.Health = GameManager.Health;
        _playerStat.FirstAidCount = GameManager.FirstAidCount;
        
        var jsonStr = JsonUtility.ToJson(_playerStat);
        uploadedFile = GoogleDriveFunctions.Upload(jsonStr);
    }
    
    public void LoadStats()
    {
        File output = GoogleDriveFunctions.Download(uploadedFile.Id);
        Debug.Log(output);
    }
}
