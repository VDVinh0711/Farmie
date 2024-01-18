using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;


namespace  SavingSystem
{
public class SavingSystem : MonoBehaviour
{
    private string _pathFarm = Application.dataPath + "/dataFarm.json";

    private void Awake()
    {
        
       
        EventManager.RegisterEvent("Savedata",LoadSaveData);
        EventManager.RegisterEvent("LoadData",LoadData);
        EventManager.RegisterEvent("DeleteSave", DeleteSaveFile);
    }
    public void LoadSaveData()
    {
        
        var SaveAbles = GetComponentsInChildren<ISaveSystem>().ToList();
        Dictionary<string, object> savePLayer = new Dictionary<string, object>();
        foreach (var saveable in SaveAbles)
        {
            savePLayer[saveable.GetType().ToString()] = saveable.SaveData();
        }
        var savePlayerString = JsonConvert.SerializeObject(savePLayer);
        File.WriteAllText(_pathFarm,savePlayerString);
       
    }
    public void LoadData()
    {
      
        if(!File.Exists(_pathFarm)||!File.Exists(_pathFarm)) return;
        var dataFarm = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(_pathFarm));
        foreach (var saveable in GetComponentsInChildren<ISaveSystem>())
        {
            string typeString = saveable.GetType().ToString();
            if (dataFarm.ContainsKey(typeString))
            {  
                saveable.LoadData(dataFarm[typeString]);
            }
        }
    }

    private void DeleteSaveFile()
    {
        if (File.Exists(_pathFarm))
        {
            File.Delete(_pathFarm);
        }
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener("Savedata",LoadSaveData);
        EventManager.RemoveListener("LoadData",LoadData);
        UIManager.Destroy();
        
    }
}
    
}

