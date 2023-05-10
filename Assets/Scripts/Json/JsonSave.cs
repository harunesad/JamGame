using UnityEngine;

public class JsonSave : MonoBehaviour
{
    public static JsonSave jsonSave;
    public SaveVariable sv;
    private void Awake()
    {
        jsonSave = this;
    }
    void Start()
    {
        sv = SaveManager.Load();
    }
}
