using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class UI_Inventory : AbsCheckOutSide
{
    [SerializeField] private GameObject _inventorySLotPrefabs;
    [SerializeField] private List<UI_Inventoryslot> _slots;
    [SerializeField] private Transform root;
    [SerializeField] private UI_OptionItem _uiOptionItem;
    public UI_OptionItem UIOptionItem => _uiOptionItem;
    
    private void Start()
    {
        InstanstializeInventoryUI();
    }
    public void InstanstializeInventoryUI()
    {
        if (_inventorySLotPrefabs == null) return;
        for (int i=0;i< Inventory.Instance.Size; i++)
        {
            var UISLot = Instantiate(_inventorySLotPrefabs,root);
            var UIslotScript = UISLot.gameObject.GetComponent<UI_Inventoryslot>();
            UIslotScript.AssighIndex(i);
            UIslotScript.Display(Inventory.Instance.Slot[i]);
            _slots.Add(UIslotScript);
        }
       RenderInventory();
       Inventory.Instance.StateChangeInventory += RenderInventory;
    }
    private void RenderInventory()
    {
        for(int i=0;i<_slots.Count;i++)
        {
            _slots[i].Display(Inventory.Instance.Slot[i]);
        }   
    }
    public void ShowInventory()
    {
        var uishow = root.parent.transform;
        if (uishow.gameObject.activeSelf)
        {
            UIManager.HideUI((uishow));
            RemoveClick();
        }
        else
        {
            RenderInventory();
            _isOutSide = true;
            UIManager.OpenUI(root.parent.transform);
            regisclick();
         
        }
       
    }

   protected override void Click(InputAction.CallbackContext obj)
    {
        if(!_isOutSide) return;
        UIManager.HideUI((root.parent.transform));
        RemoveClick();
    }
}
