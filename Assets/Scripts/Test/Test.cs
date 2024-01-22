using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using InventorySystem;
using Player;
using UnityEngine;

public class Test : MonoBehaviour
{
   [SerializeField] private ItemObject carrot;
   [SerializeField] private ItemObject item1;
   [SerializeField] private ItemObject item2;
   
   [SerializeField] private ItemSlot _product;
 


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
      ItemSlot itemSlot = BagsManager.Instance.Slot[0];
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
       _product = carrot  is IStackAble
         ? new ItemSlotStack(carrot, 1)
         : new ItemSlotDura(carrot);
      BagsManager.Instance.AddItem2(_product);
   }
   
   
}
