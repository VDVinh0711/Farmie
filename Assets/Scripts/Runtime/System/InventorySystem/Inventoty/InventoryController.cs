using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Bag _bag;

    public void ItemInventoryToBag(UI_Inventoryslot uiInventoryslot)
    {
        uiInventoryslot.Slot.IsActive = false;
        int quantity = 1;
        if (uiInventoryslot.Slot is ItemSlotStack)
        {
            quantity = (uiInventoryslot.Slot as ItemSlotStack).NumberItem;
        }
        if (!_bag.AddItem(uiInventoryslot.Slot.Item, quantity)) return;
        uiInventoryslot.Slot.SetEmty();
       _inventory.NotifyChangeInventory();
    }
}
