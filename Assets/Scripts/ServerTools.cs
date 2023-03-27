using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using File = UnityGoogleDrive.Data.File;

public static class ServerTools 
{
    public static async void SaveStats()
    {
        PlayerStat _playerStat = new PlayerStat();
        
        _playerStat.Health = GameManager.Health;
        _playerStat.FirstAidCount = GameManager.FirstAidCount;
        
        var jsonStr = JsonUtility.ToJson(_playerStat);
        var uploadedFile = await GoogleDriveFunctions.UpdloadAsync(jsonStr);
        GoogleDriveFunctions.LastUploadedFile = uploadedFile;

        SaveToLocalStorage(jsonStr);
        
        Debug.Log("[DATA_SAVED] ID: " + uploadedFile.Id + " name: " + uploadedFile.Name);
    }
   
    public static async void LoadStats(bool local = false)
    {
        if (local)
        {
            var localDataStr = LoadFromLocalStorage();

            if (localDataStr != null)
            {
                SetDownLoadedStats(localDataStr);                
                return;
            }
            else
                Debug.LogError("[DATA_LOADED_FROM_LOCAL] NO_DATA");
        }
        
        var downloadedFile = await GoogleDriveFunctions.DownloadAsync();

        if (downloadedFile != null)
        {
            GoogleDriveFunctions.LastDownloadedFile = downloadedFile;
            SetDownLoadedStats(Encoding.UTF8.GetString(downloadedFile.Content));
            
            Debug.Log("[DATA_LOADED_FROM_SERVER] output: " + Encoding.UTF8.GetString(downloadedFile.Content));
        }
    }

    private static void SetDownLoadedStats(String downloadedContent)
    {
        var parsedData = JsonUtility.FromJson<PlayerStat>(downloadedContent);
        
        GameManager.Health = parsedData.Health;
        GameManager.FirstAidCount = parsedData.FirstAidCount;
    }

    private static void SaveToLocalStorage(String json)
    {
        Debug.Log("[DATA_LOCAL_SAVED] OK");
        PlayerPrefs.SetString("Stats", json);
    }

    public static String LoadFromLocalStorage()
    {
        var str = PlayerPrefs.GetString("Stats");
        Debug.Log("[DATA_LOADED_FROM_LOCAL] output: " + str);
        
        return str;
    }
}