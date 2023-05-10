using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveManager
{
    public static string directory = "/SaveData/";
    public static string fileName = "SaveProduct.json";
    public static void Save(SaveVariable sv)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        string json = JsonUtility.ToJson(sv);
        File.WriteAllText(dir + fileName, json);
        Debug.Log(dir);
    }
    public static SaveVariable Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        SaveVariable so = new SaveVariable();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            so = JsonUtility.FromJson<SaveVariable>(json);
        }
        else
        {
            Debug.Log("sadas");
        }
        return so;
    }
}
