using System;
using UnityEngine;

namespace InventorySystem
{
    
    [Serializable]
    public  class ItemSlot
    {
        public event Action<ItemSlot> StateActionChange; 
        [SerializeField] protected Item_SO _item;
        [SerializeField] private bool _isactive = false;
        public string ID => _item==null? string.Empty : _item.ID;
        public bool HasItem()
        {
            return _item != null;
        }
        public Item_SO Item
        {
            get => _item;
            set
            {
                _item= value;
                
                OnStateChange();
            }
        }

        public bool IsActive
        {
            get => _isactive;
            set
            {
                _isactive = value;
                OnStateChange();
            }
        }
        public ItemSlot(Item_SO item)
        {
            _item = item;
        }
        public ItemSlot(ItemSlot item)
        {
            if(!item.HasItem()) return;
            _item = item.Item;
          
        }
        public ItemSlot()
        {
        }
       public virtual void SetEmty()
       {
           _item = null;
            OnStateChange();
       }
       public virtual void UseItem()
       {
           switch (_item)
           {
               case IStackAble itemStack:
                   if(itemStack.CurrentStack <=0) SetEmty();
                   break;
               case AgriculturalSo itemAgri:
                   if(itemAgri.CurrentDura <=0) SetEmty();
                   break;
           }
           OnStateChange();
       }
       protected void OnStateChange()
       {
           StateActionChange?.Invoke(this);
       }

    }

}

