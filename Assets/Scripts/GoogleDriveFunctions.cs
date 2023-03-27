using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.Assertions;
using UnityEngine;
using UnityGoogleDrive;
using UnityGoogleDrive.Data;

namespace DefaultNamespace
{
    public static class GoogleDriveFunctions
    {

        public static File LastUploadedFile;
        public static File LastDownloadedFile;
        
        public async static System.Threading.Tasks.Task<UnityGoogleDrive.Data.File> UpdloadAsync(String obj)
        {
            LastUploadedFile = null;

            var file = new File { Name = "GameData.json", Content = Encoding.ASCII.GetBytes(obj) };
            
            var request = GoogleDriveFiles.Create(file);
            return await request.Send();
        }
        

        public async static System.Threading.Tasks.Task<UnityGoogleDrive.Data.File> DownloadAsync()
        {
            LastDownloadedFile = null;
            
            if (LastUploadedFile == null)
            {
                Debug.LogError("[DOWNLOAD_ERROR] last uploaded file is null");
                return null;
            }
                 
            
            var request = GoogleDriveFiles.Download(LastUploadedFile.Id);
            return await request.Send();
        }
    }
}