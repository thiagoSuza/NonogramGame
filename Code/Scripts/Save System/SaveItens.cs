using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveItens : MonoBehaviour
{
    [SerializeField]
    private string _iten;

    public string filePath;

    [System.Serializable]
    public class ItemData
    {
        public string name;
        public int id;
        public bool win;
    }

    [System.Serializable]
    public class SaveData
    {
        public ItemData[] items;
    }

    private SaveData data;

    void Start()
    {
        LoadDataFromFile();
        
        UpdateItemWin(_iten, true); 
        
        SaveDataToFile();
    }

    private void LoadDataFromFile()
    {
        string jsonString = System.IO.File.ReadAllText(filePath);
        data = JsonUtility.FromJson<SaveData>(jsonString);
    }

    private void SaveDataToFile()
    {
        string json = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(filePath, json);
    }

    private void UpdateItemWin(string itemName, bool isWin)
    {
        for (int i = 0; i < data.items.Length; i++)
        {
            if (data.items[i].name == itemName)
            {
                data.items[i].win = isWin; 
                break;
            }
        }
    }
}
