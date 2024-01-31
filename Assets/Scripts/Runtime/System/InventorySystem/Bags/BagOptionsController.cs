using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


namespace InventorySystem
{
    public class BagOptionsController : MonoBehaviour
    {
        [FormerlySerializedAs("_bagsManager")] [SerializeField] private Bag bag;
        [SerializeField] private Inventory _inventory;


        public void UseItem(UI_BagSlots uiBagSlots)
        {
            uiBagSlots.Slot.IsActive = false;
            bag.InventoHand(uiBagSlots.getIndexItem());
        }

        public void AddItemtoInventory(UI_BagSlots uiBagSlots)
        {
            int quantity = 1;
            if (uiBagSlots.Slot is ItemSlotStack)
            {
                quantity = (uiBagSlots.Slot as ItemSlotStack).NumberItem;
            }
            if( !_inventory.AddItem(uiBagSlots.Slot.Item, quantity)) return;
            uiBagSlots.Slot.SetEmty();
            uiBagSlots.Slot.IsActive = false;
        }

        public void DisposeItem(UI_BagSlots uiBagSlots)
        {
            uiBagSlots.Slot.SetEmty();
        }
    }
}

