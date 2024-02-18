using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using InventorySystem;
using Player;
using UnityEngine;
using Object = UnityEngine.Object;

public class Test : MonoBehaviour
{
   [SerializeField] private ItemObject carrot;
   [SerializeField] private ItemObject item1;
   [SerializeField] private ItemObject item2;
   [SerializeField] private ItemSlot _product;
   [SerializeField] private ItemSlot _product2;
   [SerializeField] private List<float> lais = new();
   [SerializeField] private float rootMoney;
   private void Start()
   {
      TestRef();
      LaiSuat();
   }

   public void AddTest()
   {
      EventManger<Object>.RaiseEvent("CheckMission",carrot);
   }

   public void AddExperien()
   {
      PlayerController.Instance.PlayerExperience.AddExperience(100);
   }

   public void SkipTIme()
   {
     // TimeManager.Instance.SetupTime(300);
 
     Debug.Log(GameTime.ShowTime(GameTime.GetRealTIme()));
   }

   public void TestCraf()
   {
        /* var carrotct = CeatItemCraftSO.GetItemScraft(item1, item2);
         BagsManager.Instance.AddItem(carrotct, 3);*/

   }

   public void Tesst()
   {
      ItemSlot itemSlot = Bag.Instance.Slot[0];
      switch (itemSlot)
      {
         case ItemSlotStack:
            print("Stack");
            break;
         case ItemSlotDura:
            print("dura");
            break;
      }
   }

   public void TestAdd()
   {
      Bag.Instance.AddItem(item1, 5);
      Bag.Instance.AddItem(item2, 5);
   }

   public void TestRef()
   {
      _product = new ItemSlotStack();
      _product2 = new ItemSlotStack(carrot,6);
      _product = _product2;
      
      

   }

   private void LaiSuat()
   {
      rootMoney = rootMoney * 1000000;
      foreach (var lai in lais)
      {
         rootMoney += rootMoney * lai / 100 * 13 / 12;
      }
      Debug.Log(rootMoney /1000000);
   }
   
   
   
   
}
