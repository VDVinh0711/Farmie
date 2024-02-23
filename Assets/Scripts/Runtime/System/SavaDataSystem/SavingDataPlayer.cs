using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;


namespace  SavingSystem
{
    public class SavingDataPlayer : MonoBehaviour
    {
    private const string nameKeyData = "DataPlayer";


    private void Awake()
    {
        LoadData();
    }

    public void LoadSaveData()
    {
        var SaveAbles = GetComponentsInChildren<ISaveData>().ToList();
        Dictionary<string, object> savePLayer = new Dictionary<string, object>();
        foreach (var saveable in SaveAbles)
        {
            savePLayer[saveable.GetType().ToString()] = saveable.SaveData();
        }

        var savePlayerString = JsonConvert.SerializeObject(savePLayer);
        SendDatatoPlayFab(savePlayerString);
    }
    private void SendDatatoPlayFab(string datas)
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                { nameKeyData, datas }
            }
        };
        PlayFabClientAPI.UpdateUserData(request,OnSendSucess,OnError);
    }
    public void LoadData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnLoadDataRecive , OnError);
    }
    private void OnLoadDataRecive(GetUserDataResult result)
    {
        if (!(result.Data != null && result.Data.ContainsKey(nameKeyData))) return;
        var dataFarm = JsonConvert.DeserializeObject<Dictionary<string, object>>(result.Data[nameKeyData].Value);
            foreach (var saveable in GetComponentsInChildren<ISaveData>())
            {
                string typeString = saveable.GetType().ToString();
                if (dataFarm.ContainsKey(typeString))
                {  
                    saveable.LoadData(dataFarm[typeString]);
                }
            }
    }
    private void OnSendSucess(UpdateUserDataResult obj)
    {
        print("Send data player sucess");
    }
    private void OnError(PlayFabError obj)
    {
        print("Senddata player error" + obj.ToString());
    }


    private void OnDestroy()
    {
        LoadSaveData();
    }
    }
    
    
}

