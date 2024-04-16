using System.Collections;
using System.Collections.Generic;
using System.Linq;
using InventorySystem;
using UnityEngine;

public class BagController : MonoBehaviour
{
   [SerializeField] private Bag _bag;
   [SerializeField] private ItemSlot handItem;
   [SerializeField] private ItemSlot[] slotItemBag =>_bag.Slot;

   public ItemSlot HandItem => handItem;
   public void ItemtoHand(int index)
   {
      if (!slotItemBag[index].HasItem()) return;
      if(!(slotItemBag[index].Item is EquidmentSo)) return;    
      SwapItemBag(ref slotItemBag[index], ref handItem);
      _bag.OnChangeBag();
      _bag.OnChangeHand();
   }
   public void IteminHandtoBag()
   {
      if(!handItem.HasItem()) return;
      var index = FindIndexSlotEmTy();
      if (handItem is ItemSlotStack)
      {
         slotItemBag[index] = new ItemSlotStack(handItem.Item, (handItem as ItemSlotStack).NumberItem);
      }
      else
      {
         slotItemBag[index] = new ItemSlotDura(handItem as ItemSlotDura);
      }
      handItem.SetEmty();
      _bag.OnChangeBag();
      _bag.OnChangeHand();
   }
   private int FindIndexSlotEmTy()
   {
      for (int i = 0; i < _bag.Size; i++)
      {
         if (!_bag.Slot[i].HasItem()) return i;
      }
      return -1;
   }

   private void SwapItemBag(ref ItemSlot item1 , ref ItemSlot item2)
   {
      ItemSlot temp = new ItemSlot();
      temp = item1;
      item1 = item2;
      item2 = temp;
   }

   public void  SwapWithItemInBag(ItemSlot itemSlotBag, ItemSlot otherItem)
   {
      int quantity = otherItem is ItemSlotStack itemSlotStack ? itemSlotStack.NumberItem : 1;  
      if (!otherItem.HasItem())
      {
         otherItem.Item = itemSlotBag.Item;
         itemSlotBag.SetEmty();
         return;
      }
      var temp = otherItem.Item;
      
      otherItem.Item = itemSlotBag.Item;
      itemSlotBag.SetEmty();
      _bag.AddItem(temp, quantity);

   }


   public ItemSlot GetItemInBagById(string id , int quantity)
   {
      var itemGet = _bag.Slot.FirstOrDefault(x => x.ID.Equals(id));
      if (itemGet == null) return null;
      var result = new ItemSlot();
      switch (itemGet)
      {
         case ItemSlotStack itemSlotStack:
            result = new ItemSlotStack(itemSlotStack.GetItemSlotStack(quantity) );
            break;
         default:
            result = new ItemSlot(itemGet.Item);
            itemGet.SetEmty();
            break;
      }
      return result;
   }
   
   
   
   
}
