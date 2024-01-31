
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;


namespace InventorySystem
{
    public class UI_Bags : AbsCheckOutSide
    {
     [SerializeField] private GameObject inventorySlotPrefab;
    [SerializeField] private UI_BagSlots handSlotUI;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private List<UI_BagSlots> inventorySlots;
    [SerializeField] private Transform inventoryRoot;
    [SerializeField] private UI_ItemBagOption itemBagOptionsUI;
    [SerializeField] private Bag bag;
    public UI_ItemBagOption ItemBagOptions => itemBagOptionsUI;

    private void Start()
    {
        inventoryRoot = transform.GetChild(0).GetChild(2);
        InitializeBag();
    }

    public void InitializeBag()
    {
        if (inventorySlotPrefab == null) return;
        for (int i = 0; i < bag.Size; i++)
        {
            var slotUI = Instantiate(inventorySlotPrefab, inventoryRoot);
            var slotScript = slotUI.gameObject.GetComponent<UI_BagSlots>();
            slotScript.AssighIndex(i);
            slotScript.Display(bag.Slot[i]);
            slotScript.ShowItemDescriptionEvent += ShowItemDescription;
            inventorySlots.Add(slotScript);
        }
        handSlotUI.Display(bag.HandItem);
        RenderBagContents();
        Bag.Instance.StateChangeBags += RenderBagContents;
    }

    private void RenderBagContents()
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            inventorySlots[i].Display(Bag.Instance.Slot[i]);
        }
        handSlotUI.Display(Bag.Instance.HandItem);
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
            UIManager.HideUI(uiTransform);
            RemoveClick();
            return;
        }

        RenderBagContents();
        UIManager.OpenUI(uiTransform);
        regisclick();
    }


    protected override void Click(InputAction.CallbackContext obj)
    {
         if (_isOutSide)
        {
            UIManager.HideUI((inventoryRoot.parent.transform));
            _isOutSide = false;
        }
    }
    }
}

