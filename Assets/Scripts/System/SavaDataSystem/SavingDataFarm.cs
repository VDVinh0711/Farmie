using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

namespace  SavingSystem
{
public class SavingDataFarm : MonoBehaviour
{
    private const string nameKeyData = "DataFarm";

    public void LoadSaveData()
    {
        var SaveAbles = GetComponentsInChildren<ISaveData>().ToList();
        Dictionary<string, object> savePLayer = new Dictionary<string, object>();
        foreach (var saveable in SaveAbles)
        {
            savePLayer[saveable.GetType().ToString()] = saveable.SaveData();
        }

        savePLayer["TimeOut"] = GameTime.GetRealTIme();
        var savePlayerString = JsonConvert.SerializeObject(savePLayer);
      //  SendDatatoPlayFab(savePlayerString);
      PlayFabData.PushDataIntoPlayFab(nameKeyData,savePlayerString);
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
        //PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnLoadDataRecive , OnError);
        PlayFabData.GetDataOnPlayFab(OnLoadDataRecive);
    }
    private void OnLoadDataRecive(GetUserDataResult result)
    {
        if (!(result.Data != null && result.Data.ContainsKey("DataFarm"))) return;
        var dataFarm = JsonConvert.DeserializeObject<Dictionary<string, object>>(result.Data[nameKeyData].Value);
            foreach (var saveable in GetComponentsInChildren<ISaveData>())
            {
                string typeString = saveable.GetType().ToString();
                if (dataFarm.ContainsKey(typeString))
                {  
                    saveable.LoadData(dataFarm[typeString]);
                }
            }
            try
            {
                var timeout = JsonConvert.DeserializeObject<GameTime>(dataFarm["TimeOut"].ToString());
                TimeManager.Instance.SetupTime(timeout,GameTime.GetRealTIme());
            }
            catch (JsonException ex)
            {
                Debug.LogError("Error deserializing GameTime from JSON: " + ex.Message);
            }
            print("load data recive");

        
    }
    private void OnSendSucess(UpdateUserDataResult obj)
    {
        print("Send data farm sucess");
    }
    private void OnError(PlayFabError obj)
    {
        print("Senddata farm error" + obj.ToString());
    }
}
    
}

