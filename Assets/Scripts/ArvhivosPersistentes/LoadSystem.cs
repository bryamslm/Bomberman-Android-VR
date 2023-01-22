using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class LoadSystem
{

    public static void saveData<T>(T data, string path = "Data/BombermanRV", string fileName = "GameInfo")
    {
        string fullPath = Application.persistentDataPath + "/" + path + "/";
        bool checkFolderExist = Directory.Exists(fullPath);
        if (!checkFolderExist)
        {
            Directory.CreateDirectory(fullPath);
        }
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(fullPath + fileName + ".json", json);
        Debug.Log("Save data to " + fullPath + fileName + ".json");

    }

    public static T loadData<T>(string path = "Data/BombermanRV", string fileName = "GameInfo")
    {
        string fullPath = Application.persistentDataPath + "/" + path + "/" + fileName + ".json";
        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            T data = JsonUtility.FromJson<T>(json);
            Debug.Log("Load data from " + fullPath);
            return data;
        }
        else
        {
            Debug.LogError("File not found in " + fullPath);
            return default(T);
        }
    }


   
}
