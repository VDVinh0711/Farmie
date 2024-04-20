using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace InventorySystem
{
    
    [Serializable]
    public  abstract  class Item
    {
      
        [SerializeField] protected Item_SO _itemInfor;
        public string ID => _itemInfor==null? string.Empty : _itemInfor.ID;
        public bool HasItem()
        {
            return _itemInfor != null;
        }
        public Item_SO ItemInfor => _itemInfor;
        public Item(Item_SO itemInfor)
        {
            _itemInfor = itemInfor;
        }
        public Item(Item item)
        {
            if(!item.HasItem()) return;
            _itemInfor = item.ItemInfor;
        }
        public abstract void UseItem();
        public virtual void SetEmty()
        {
            _itemInfor = null;
        }
        public abstract Item ItemClone();

    }

}

