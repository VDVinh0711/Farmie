
using InventorySystem;
using Player;
using UI.UI_Shop;
using UnityEngine;
using UnityEngine.UI;

public class ShellItemController : MonoBehaviour
{
    [SerializeField] private UI_InventoryInShopSlot  _itemSell;
    [SerializeField] private Shop _shop;
    public UI_InventoryInShopSlot Itemsell => _itemSell;

    public int maxQuantityShell => _itemSell.Itemslot.HasItem() && _itemSell.Itemslot.Item is ItemStack stack
        ? stack.NumberItem
        : 1;
    public void AsignItemBuy(UI_InventoryInShopSlot itemsell)
    {
        if (_itemSell!=null)
        { 
            _itemSell.Itemslot.IsActive = false;
            _itemSell.UpdateViewItem(_itemSell.Itemslot);
        }

        _itemSell = itemsell;
        _itemSell.Itemslot.IsActive = true;
        _itemSell.UpdateViewItem(_itemSell.Itemslot);
        
    }
    public void SellItem(int quantity = 1)
    {
        if(!_itemSell.Itemslot.HasItem()) return;
        switch (_itemSell.Itemslot.Item)
        {
            case ItemStack itemStack:
                if(itemStack.NumberItem <  quantity ) return;
                _itemSell.Itemslot.IsActive = false;
                var moneySell = (_itemSell.Itemslot.Item.ItemInfor as ItemInvenSo).Price * quantity;
                _shop.PlayerManager.PlayerStats.Earn(moneySell);
                itemStack.PreviousItem(quantity);
                break;
            // add more if wana buy another kind item
        }

        
        _itemSell.UpdateViewItem(_itemSell.Itemslot);
    }

    public void SellAllItem()
    {
        if(!_itemSell.Itemslot.HasItem()) return;
        _itemSell.Itemslot.IsActive = false;
        switch (_itemSell.Itemslot.Item)
        {
            case ItemStack itemStack:
                var moneySell = (_itemSell.Itemslot.Item.ItemInfor as ItemInvenSo).Price * itemStack.NumberItem;
                _shop.PlayerManager.PlayerStats.Earn(moneySell);
                itemStack.SetEmty();
                print(itemStack.HasItem());
                break;
            // add more if wana buy another kind item
        }
        _itemSell.UpdateViewItem(_itemSell.Itemslot);
    }
}
