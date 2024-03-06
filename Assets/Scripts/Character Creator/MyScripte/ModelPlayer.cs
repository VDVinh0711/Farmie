using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ModelPlayer : MonoBehaviour
{
   [SerializeField] public List<BodayPartPlayer> _listpartPlayer = new();
   private PlayFabDataManager _playFabDataManager;
   private void Awake()
   {
      _playFabDataManager = new PlayFabDataManager();
      _playFabDataManager.GetDataOnPlayFab(LoadData);
   }
   public void Set(string name, SO_body_part soBodyPart)
   {
      foreach (var partPlayer in _listpartPlayer)
      {
         if(partPlayer.name != name) continue;
         partPlayer.SoBodyPart = soBodyPart;
      }
   }
   public string SaveData()
   {
      var listsave = new List<SaveModelPlayer>();
     
      for (int i = 0; i < _listpartPlayer.Count; i++)
      {
         listsave.Add(new SaveModelPlayer(_listpartPlayer[i].name, _listpartPlayer[i].SoBodyPart.bodypartAnimationID)) ;
      }
      return JsonConvert.SerializeObject(listsave);
   }
   public void LoadData(GetUserDataResult result)
   {
      
      if (!(result.Data != null && result.Data.ContainsKey("Bodypart"))) return;
      var dataFarm = JsonConvert.DeserializeObject<List<SaveModelPlayer>>(result.Data["Bodypart"].Value);
      for (int i = 0; i < dataFarm.Count; i++)
      {
         if (dataFarm[i].namePart == _listpartPlayer[i].name)
         {
            _listpartPlayer[i].SoBodyPart = SO_body_part.Get_body_Part_ByID(dataFarm[i].namePart,dataFarm[i].idPart);
         }
      }

      ReloadSkin();
   }
   public void LoadSave()
   {
      _playFabDataManager.PushDataIntoPlayFab("Bodypart",SaveData());
      SceneManager.LoadScene("FarmScene");
   }

   public void ReloadSkin()
   {
      GetComponent<BodypartController>().UpdateBodyPart();
   }
   private void OnDestroy()
   {
      _playFabDataManager.PushDataIntoPlayFab("Bodypart",SaveData());
   }
}

[Serializable]
public class BodayPartPlayer
{
   public string name;
   public SO_body_part SoBodyPart;
}
public struct SaveModelPlayer
{
   public string namePart;
   public string idPart;

   public SaveModelPlayer(string namePart, string idPart)
   {
      this.namePart = namePart;
      this.idPart = idPart;
   }
}
