
using System;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField] private GameObject _inventorySLotPrefabs;
    [SerializeField] private List<UI_Inventoryslot> _slots;
    [SerializeField] private Transform root;
    [FormerlySerializedAs("_uiOptionItem")] [SerializeField] private UI_OptionItemInven uiOptionItemInven;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private RectTransform _panel;
    [SerializeField] private Button _btnClose;
    public UI_OptionItemInven UIOptionItemInven => uiOptionItemInven;

    private void Awake()
    {
        _btnClose.onClick.AddListener(HideInvetory);
    }
    private void Start()
    {
        InstanstializeInventoryUI();
    }
    public void InstanstializeInventoryUI()
    {
        if (_inventorySLotPrefabs == null) return;
        for (int i=0;i< _inventory.Slot.Length; i++)
        {
            var UISLot = Instantiate(_inventorySLotPrefabs,root);
            var UIslotScript = UISLot.gameObject.GetComponent<UI_Inventoryslot>();
            UIslotScript.AssighIndex(i);
            UIslotScript.Display(_inventory.Slot[i]);
            _slots.Add(UIslotScript);
        }
       RenderInventory();
       _inventory.Changeinventory += RenderInventory;
    }
    private void RenderInventory()
    {
        for(int i=0;i<_inventory.Slot.Length;i++)
        {
            _slots[i].Display(_inventory.Slot[i]);
        }   
    }
    public void ToggelInventory()
    {
        if (_panel.gameObject.activeSelf)
        {
            HideInvetory();
            return;
        }
        OpenInvetory();
    }
    private void OpenInvetory()
    {
        RenderInventory();
        UIManager.OpenUI(_panel);
    }

    private void HideInvetory()
    {
        UIManager.HideUI((_panel));
    }
    private void OnDestroy()
    {
        _inventory.Changeinventory -= RenderInventory;
    }
}
