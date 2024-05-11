using System;
using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Bag _bag;
    [SerializeField] private UI_Inventoryslot _currentSlot;
    [SerializeField] private UI_OptionItemInven _uiOptionItem;
    private void Awake()
    {
        _inventory = transform.parent.GetComponent<Inventory>();
    }
    
    public void ItemInventoryToBag()
    {
        _bag = _inventory.PlayerManager.Bag;
        if(_bag == null) return;
        _currentSlot.Slot.IsActive = false;
        if (!_bag.AddItem(_currentSlot.Slot.Item)) return;
        _currentSlot.Slot.SetEmty();
       _inventory.NotifyChangeInventory();
    }

    public void ActiveItemInVen(UI_Inventoryslot uiInventoryslot)
    {
        if (_currentSlot != null)
        {
            _currentSlot.Slot.IsActive = false;
            
        }
        _currentSlot = uiInventoryslot;
        _currentSlot.Slot.IsActive = true;
        _uiOptionItem.ShowOption(_currentSlot);
    }
}
