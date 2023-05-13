using UnityEngine;
using System.IO;

public static class SaveManager
{
    public const string directory = "/SaveData/";
    public const string fileName = "SaveProduct.json";
    public static void Save(SaveVariable sv)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        string json = JsonUtility.ToJson(sv);
        File.WriteAllText(dir + fileName, json);
    }
    public static SaveVariable Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        SaveVariable sv = new SaveVariable();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            sv = JsonUtility.FromJson<SaveVariable>(json);
        }
        else
        {
            Debug.Log("Ulaþýlamadý");
        }
        return sv;
    }
}
