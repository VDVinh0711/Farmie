
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
            print(savePlayerString);
            PlayFabData.PushDataIntoPlayFab(nameKeyData,savePlayerString);
        }
        public void LoadData()
        {
            //PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnLoadDataRecive , OnError);
           PlayFabData.GetDataOnPlayFab(OnLoadDataRecive);
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
        private void OnDisable()
        {
            LoadSaveData();
        }
    }
  
}

