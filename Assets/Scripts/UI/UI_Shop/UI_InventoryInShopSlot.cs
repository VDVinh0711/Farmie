
using System;
using InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UI_InventoryInShopSlot : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private Image _imageItem;
    [SerializeField] private TextMeshProUGUI _textQuantity;
    [SerializeField] private ItemSlot item;
    [SerializeField] private Image _itemActive;
    public ItemSlot Itemslot
    {
        get => item;
        set
        {
            item = value;
        }
    }

    public void UpdateViewItem(ItemSlot  itemslot)
    {
        item = itemslot;
        _imageItem.enabled = item.HasItem();
        _itemActive.enabled = item.IsActive && item.HasItem() ;
        _textQuantity.enabled = item.HasItem();
        if (!item.HasItem())
        {
            Destroy(this.gameObject);
            return;
        }
        _textQuantity.enabled = item.Item is ItemStack;
        _imageItem.sprite = item.Item.ItemInfor.UIinInven;
        var settext = item.Item is ItemStack stack ? stack.NumberItem + "" : "";
        _textQuantity.SetText(settext);
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        
        var shellItemController = FindObjectOfType<ShellItemController>();
        if(shellItemController == null) return;
        shellItemController.AsignItemBuy(this);
    }
}
