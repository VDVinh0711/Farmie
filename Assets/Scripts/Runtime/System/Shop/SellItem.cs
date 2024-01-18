using System;
using InventorySystem;
using Player;

namespace Shop123
{
    [Serializable]
    public class SellItem
    {
        private ItemInvenObject _itemsell;
        private int _quantity;
        private BagsManager _bagsManager;

        public SellItem( BagsManager bagsManager)
        {
            _bagsManager = bagsManager;
        }
        public void SellAll(ItemSlot itemSlot)
        {
            var item = itemSlot as ItemSlotStack;
            if(item == null) return;
            _itemsell = itemSlot.Item as ItemInvenObject;
            if(_itemsell== null) return;
           _quantity = item.NumberItem;
            float cost = _itemsell.Price * _quantity;
            PlayerController.Instance.PlayerStats.Earn(cost);
            _bagsManager.RemoveItem(itemSlot,_quantity);
        }

        public void SellEachItem(ItemSlot itemsell , int quantity)
        {
            _itemsell = itemsell.Item as ItemInvenObject;
            if(_itemsell== null) return;
            _quantity = quantity;
            float cost = _itemsell.Price * _quantity;
           _bagsManager.RemoveItem(itemsell,_quantity);
        }
    }
}