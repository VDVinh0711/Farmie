using System;
using UnityEngine;

namespace InventorySystem
{
    
    [Serializable]
    public  class ItemSlot
    {
        //public virtual event Action<ItemSlot>  StatechangeUI;
        [SerializeField] private ItemObject _item;
        public  bool IsstackAble;
        [SerializeField] private bool _isactive = false;
        public string ID => _item.ID;
        public bool HasItem()
        {
            return _item != null;
        }
        public ItemObject Item
        {
            get => _item;
            set
            {
                _item= value;
                if(value == null) return;
                IsstackAble = value is IStackAble;
                //NotifyAboutStateChange();
            }
        }

        public bool IsActive
        {
            get => _isactive;
            set
            {
                _isactive = value;
                //NotifyAboutStateChange();
            }
        }
        /*protected virtual void NotifyAboutStateChange()
        {
            Debug.Log("Call Statechange");
            Debug.Log(StatechangeUI == null);
          StatechangeUI?.Invoke(this);
        }*/
        public ItemSlot(ItemObject item)
        {
            Item = item;
            IsstackAble = item is IStackAble;
        }
        public ItemSlot(ItemSlot item)
        {
            Item = item.Item;
            IsstackAble = item.IsstackAble;
        }
        public ItemSlot()
        {
            
        }
       public virtual void SetEmty()
       {
           _item = null;
           IsstackAble = false;
           //NotifyAboutStateChange();
       }

       public virtual void UseItem()
       {
           if (this is ItemSlotStack)
           {
               (this as ItemSlotStack).UseItem();
           }
           else
           {
               (this as ItemSlotDura).UseItem();
           }
       }


    }

}

