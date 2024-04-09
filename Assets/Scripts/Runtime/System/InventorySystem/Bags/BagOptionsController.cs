using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


namespace InventorySystem
{
    public class BagOptionsController : MonoBehaviour
    {
        [SerializeField] private Bag bag; 
        [SerializeField] private Inventory _inventory;
        [SerializeField] private ItemSlot _curentslotAccive;
        [SerializeField] private UI_Bags _uiBags;
        
        public void UseItem(int index)
        {
           
            if (bag.Slot[index] is ItemSlotClothes itemSlotClothes)
            {
               var clothesManager =  FindObjectOfType<ModelPlayerManager>();
               clothesManager.SetClothesPlayer(itemSlotClothes);
                return;
            }
            bag.BagController.ItemtoHand(index);
            _uiBags.RenderBagContents();
           
        }
        public void AcctiveItemInBag(UI_BagSlots uiBagSlots)
        {
            if (_curentslotAccive != null)
            {
                _curentslotAccive.IsActive = false;
            }
            _curentslotAccive = uiBagSlots.Slot;
            _curentslotAccive.IsActive = true;
            _uiBags.ItemBagOptions.ShowOption(_curentslotAccive,uiBagSlots.getIndexItem());
            
        }
        public void AddItemtoInventory(ItemSlot itemSlot)
        {
            int quantity = 1;
            if (itemSlot is ItemSlotStack)
            {
                quantity = (itemSlot as ItemSlotStack).NumberItem;
            }
            if( !_inventory.AddItem(itemSlot.Item, quantity)) return;
            itemSlot.SetEmty();
            itemSlot.IsActive = false;
            _uiBags.RenderBagContents();
        }
        public void DisposeItem(ItemSlot itemSlot)
        {
            itemSlot.SetEmty();
        }
    }
}

