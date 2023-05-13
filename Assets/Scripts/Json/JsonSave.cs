using UnityEngine;

public class JsonSave : MonoBehaviour
{
    public static JsonSave jsonSave;
    public SaveVariable sv;
    int firstOpen;
    string firstKey = "First";
    private void Awake()
    {
        jsonSave = this;
    }
    void Start()
    {
        firstOpen = PlayerPrefs.GetInt(firstKey);
        if (firstOpen == 0)
        {
            SaveManager.Save(sv);
            firstOpen++;
            PlayerPrefs.SetInt(firstKey, firstOpen);
        }
        sv = SaveManager.Load();
    }
}
