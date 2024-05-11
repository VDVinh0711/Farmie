using System;
using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using Newtonsoft.Json;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDataModelPlayer : MonoBehaviour
{
   private const string pathSaveClothes = "ClothesPlayer";
   private const string pathSavePart = "PartPlayer";
   [SerializeField] private ModelPlayerManager _modelPlayerManager;
   private void Awake()
   {
      PlayFabData.GetDataOnPlayFab(GetDataPartPlayer);
      PlayFabData.GetDataOnPlayFab(GetDataClothesPlayer);
   }
   private void GetDataPartPlayer(GetUserDataResult resultdata)
   {
      if(!resultdata.Data.ContainsKey(pathSavePart)) return;
      List<DataModelPlayer> dataModelPlayers =JsonConvert.DeserializeObject<List<DataModelPlayer>>(resultdata.Data[pathSavePart].Value.ToString());
      foreach (var dataModelPlayer in dataModelPlayers)
      {
         foreach (var partsPlayer in _modelPlayerManager.ListPartPlayers)
         {
            if(partsPlayer.type.ToString() != dataModelPlayer.type) continue;
            var partPlayer = PartPlayerModel_SO.Get_Part_by_ID(dataModelPlayer.id);
            _modelPlayerManager.SetPartPlayer(partPlayer);
         }
      }
   }
   private void GetDataClothesPlayer(GetUserDataResult resultdata)
   {
      if(!resultdata.Data.ContainsKey(pathSaveClothes)) return;
      List<DataModelPlayer> dataModelPlayers =JsonConvert.DeserializeObject<List<DataModelPlayer>>(resultdata.Data[pathSaveClothes].Value);
      foreach (var dataModelPlayer in dataModelPlayers)
      {
         foreach (var clothesInBag in _modelPlayerManager.ListClothesPlayer)
         {
            if(clothesInBag.type.ToString() != dataModelPlayer.type) continue;
            var clothesSO = ClothesItem_SO.getItemByID(dataModelPlayer.id) as ClothesItem_SO;
            var itemslot = new ItemSlot();
            itemslot.AsignItem(clothesSO,1,out var number);
            _modelPlayerManager.SetClothesPlayer(itemslot);
         }
      }
   }
   private string PushDataPartPlayer()
   {
      var listIdPart = new List<DataModelPlayer>();
      foreach (var itemClothe in _modelPlayerManager.ListPartPlayers)
      {
         if(itemClothe.partPlayer == null) continue;
         DataModelPlayer data = new DataModelPlayer(itemClothe.partPlayer.ID, itemClothe.type.ToString());
         listIdPart.Add(data);
      }
      return JsonConvert.SerializeObject(listIdPart);
   }
   private string PushDataClothesPlayer()
   {
      var listIdPart = new List<DataModelPlayer>();
      foreach (var itemClothe in _modelPlayerManager.ListClothesPlayer)
      {
         if(!itemClothe.itemClothes.HasItem()) continue;
         DataModelPlayer data = new DataModelPlayer(itemClothe.itemClothes.Item.ItemInfor.ID, itemClothe.type.ToString());
         listIdPart.Add(data);
      }
      return JsonConvert.SerializeObject(listIdPart);
   }
   private void OnDisable()
   {
      PlayFabData.PushDataIntoPlayFab(pathSavePart,PushDataPartPlayer());
      PlayFabData.PushDataIntoPlayFab(pathSaveClothes,PushDataClothesPlayer());
   }
  
   public void ClickTest1()
   {
      SceneManager.LoadScene("ChoseMap");
   }

  
}

public struct DataModelPlayer
{
   public string id;
   public string type;
  
   public DataModelPlayer(string id, string type)
   {
      this.id = id;
      this.type = type;
   }
}
