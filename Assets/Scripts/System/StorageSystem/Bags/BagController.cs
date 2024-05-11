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
      if(!(slotItemBag[index].Item.ItemInfor is EquidmentSo)) return;
      ItemHelper.SwapWithItemSlot(slotItemBag[index], handItem);
      _bag.OnChangeBag();
      _bag.OnChangeHand();
   }
   public void IteminHandtoBag()
   {
      if(!handItem.HasItem()) return;
      _bag.AddItem(handItem.Item);
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
  
   public Item GetItemInBagById(string id , int quantity = 1)
   {
      var itemGet = _bag.Slot.FirstOrDefault(x => x.Item.ID.Equals(id));
      if (itemGet == null) return null;
      return itemGet.GetItemInventory( quantity);
   }
   
   
   
   
   
   
}
