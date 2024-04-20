
using System;
using InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemMouseHolderData : MonoBehaviour
{
    [FormerlySerializedAs("_itemSlot")] [SerializeField] private Item item;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _quantityItem;

    public Item ItemHolde => item;


    private void Start()
    {
       SetUp();
    }

    private void SetUp()
    {
        /*item = new Item();
        gameObject.SetActive(false);*/
    }
    private void Update()
    {
        UpdatePosition();
    }
    private void UpdatePosition()
    {
        gameObject.transform.position = Input.mousePosition;
    }
    public void AssignItemAnhUpDateUI(Item item)
    {
        /*this.item = MappingItem.ItemSOtoObj(item);
        UpdateUI();
        gameObject.SetActive(true);*/
    }
    public void UpdateUI()
    {
        _image.enabled = item.HasItem();
        if(!item.HasItem()) return;
        _image.sprite = item.ItemInfor.UIinInven;
        var setquantity = item is ItemStack _slotStack && _slotStack.NumberItem > 1 ? _slotStack.NumberItem +"": "";
        print((item.ItemInfor is IStackAble));
        _quantityItem.SetText(setquantity);
    }

  

    public void ClearUI()
    {
        _image.enabled = false;
        _quantityItem.SetText("");
    }
}
