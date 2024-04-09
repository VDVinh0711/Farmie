using System;
using InventorySystem;
using Player;

namespace Shop123
{
    [Serializable]
    public class SellItem
    {
        private ItemInvenSo _itemsell;
        private int _quantity;
        private Bag _bag;

        public SellItem( Bag bag)
        {
            _bag = bag;
        }
        public void SellAll(ItemSlot itemSlot)
        {
            var item = itemSlot as ItemSlotStack;
            if(item == null) return;
            _itemsell = itemSlot.Item as ItemInvenSo;
            if(_itemsell== null) return;
           _quantity = item.NumberItem;
            float cost = _itemsell.Price * _quantity;
            PlayerManager.Instance.PlayerStats.Earn(cost);
            _bag.RemoveItem(itemSlot,_quantity);
        }

        public void SellEachItem(ItemSlot itemsell , int quantity)
        {
            _itemsell = itemsell.Item as ItemInvenSo;
            if(_itemsell== null) return;
            _quantity = quantity;
            float cost = _itemsell.Price * _quantity;
           _bag.RemoveItem(itemsell,_quantity);
        }
    }
}