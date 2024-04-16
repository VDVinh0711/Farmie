
using System;
using InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemMouseHolderData : MonoBehaviour
{
    [SerializeField] private ItemSlot _itemSlot;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _quantityItem;

    public ItemSlot ItemHolde => _itemSlot;


    private void Start()
    {
       SetUp();
    }

    private void SetUp()
    {
        _itemSlot = new ItemSlot();
        gameObject.SetActive(false);
    }
    private void Update()
    {
        UpdatePosition();
    }
    private void UpdatePosition()
    {
        gameObject.transform.position = Input.mousePosition;
    }
    public void AssignItemAnhUpDateUI(Item_SO itemSo)
    {
        _itemSlot.Item = itemSo;
        UpdateUI();
        gameObject.SetActive(true);
    }
    public void UpdateUI()
    {
        _image.enabled = _itemSlot.HasItem();
        if(!_itemSlot.HasItem()) return;
        _image.sprite = _itemSlot.Item.UIinInven;
        var setquantity = _itemSlot.Item is IStackAble _slotStack && _slotStack.CurrentStack > 1 ? _slotStack.CurrentStack +"": "";
        print((_itemSlot.Item is IStackAble));
        _quantityItem.SetText(setquantity);
    }

  

    public void ClearUI()
    {
        _image.enabled = false;
        _quantityItem.SetText("");
    }
}
