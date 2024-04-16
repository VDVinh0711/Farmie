
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;


namespace InventorySystem
{
    public class UI_Bags : MonoBehaviour
    {
        [SerializeField] private GameObject inventorySlotPrefab;
        [SerializeField] private UI_BagSlots handSlotUI;
        [SerializeField] private TextMeshProUGUI itemDescriptionText;
        [SerializeField] private TextMeshProUGUI itemNameText;
        [SerializeField] private List<UI_BagSlots> _bagSlotUI;
        [SerializeField] private Transform inventoryRoot;
        [SerializeField] private UI_ItemBagOption _uibagoption;
        [SerializeField] private Bag bag;
    public UI_ItemBagOption ItemBagOptions => _uibagoption;

    private void Start()
    { 
        inventoryRoot = transform.GetChild(0).GetChild(2);
       RenderBagContents();
       RegisterEventShowDes();
       RegisterIndex();
       bag.StateChangeBags += RenderBagContents;
    }
    public void RegisterIndex()
    {
       
        for (int i = 0; i < _bagSlotUI.Count; i++)
        {
            _bagSlotUI[i].AssighIndex(i);
        }
        
    }
    public void RenderBagContents()
    {
        for (int i = 0; i < _bagSlotUI.Count; i++)
        {
            _bagSlotUI[i].Display(bag.Slot[i]);
        }
        handSlotUI.Display(bag.HandItem);
    }
    private void ShowItemDescription(string itemName, string itemDescription)
    {
        if (itemDescriptionText == null || itemNameText == null) return;
        itemDescriptionText.SetText(itemDescription);
        itemNameText.SetText(itemName);
    }
    public void ToggleBagVisibility()
    {
        var uiTransform = inventoryRoot.parent.transform;
        if (uiTransform.gameObject.activeSelf)
        {
           HideBag();
            return;
        }
        OpenBag();
    }
    private void HideBag()
    {
        _uibagoption.HideOption();
        UIManager.HideUI(inventoryRoot.parent.transform);
    }
    private void OpenBag()
    {
       RenderBagContents();
       UIManager.OpenUI(inventoryRoot.parent.transform);
    }
    private void RegisterEventShowDes()
    {
       foreach (var slot in _bagSlotUI)
       {
           slot.ShowItemDescriptionEvent += ShowItemDescription;
       }
    }
    private void RemoveEventShowDes()
    {
       foreach (var slot in _bagSlotUI)
       {
           slot.ShowItemDescriptionEvent -= ShowItemDescription;
       }
    }
    private void OnDisable()
    {
       RemoveEventShowDes();
    }
}
}

