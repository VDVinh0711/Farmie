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
        [SerializeField] private ModelPlayerManager _modelPlayer;
        public void UseItem(int index)
        {
            if (bag.Slot[index].Item is ItemClothes )
            {
                UseForClothes(index);
            }
            else
            {
                bag.BagController.ItemtoHand(index);
            }
            _uiBags.RenderBagContents();
           
        }

        private void UseForClothes(int index)
        {
            _modelPlayer.SetClothesPlayer(bag.Slot[index]);
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
        public void AddItemtoInventory(ItemSlot item)
        {
            var itemadd = item.GetItemInventory();
            if (_inventory == null) _inventory = FindObjectOfType<Inventory>();
            if( !_inventory.AddItem(itemadd)) return;
            item.SetEmty();
            item.IsActive = false;
            _uiBags.RenderBagContents();
        }
        public void DisposeItem(ItemSlot item)
        {
            item.SetEmty();
        }
    }
}

