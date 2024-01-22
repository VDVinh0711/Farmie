using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory : Singleton<Inventory>,ISaveSystem
{
        private ItemSlot[] _slots;
        private  int _size = 30;
        public static Inventory Instance;
        public  ItemSlot[] Slot=> _slots;
        public int Size => _size;   
        public event Action StateChangeInventory;
        protected virtual void Awake()
        {
            Instance = this;
        }
        private void AdjustInven()
        {
            _slots ??= new ItemSlot[_size];
         
        }
        private void OnValidate()
        {
            AdjustInven();
        }
        public bool ISFull()
        {
            return  _slots.Count(slot => slot.HasItem()) >= _size;
        }
        private ItemSlot FindSlot(ItemObject itemObject)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_slots[i].Item != itemObject) continue;
                var itemstack = _slots[i] as ItemSlotStack;
                if(itemstack == null) continue;
                if (!itemstack.CanStackAble()) continue;
                return _slots[i];
            }
            return null;
        }
        protected int FindIndexSlotEmTy()
        {
            for (int i = 0; i < _size; i++)
            {
                if (!_slots[i].HasItem()) return i;
            }
            return -1;
        }
        public bool CanAcceptItem(ItemObject item , int numberitem)
        {
            var relevanSlot = FindSlot(item );
            return !ISFull() || relevanSlot!=null;
        }
        
        public  bool AddItem(ItemObject item, int numberitem)
        {
           
            if (!CanAcceptItem(item, numberitem))
            {
                EventManger<string>.RaiseEvent("ShowNotifycation","Kho đồ đã đầy");
                return false;
            }
            var numberadd = numberitem;
            AddfollowReQuest(item, numberadd);
            OnUpdateInventory();
            return true;
        }
        private int AddFirstSlotEmty(ItemObject item , int numberitem)
        {
            var index = FindIndexSlotEmTy();
            if(index==-1) return -1;
            if (item is IStackAble)
            {
                var maxStack = (item as IStackAble).MaxStack;
                if (maxStack > numberitem)
                {
                    _slots[index] = new ItemSlotStack(item, numberitem);
                }
                else
                {
                    _slots[index] = new ItemSlotStack(item, maxStack);
                    return numberitem - maxStack;
                }
            }
            else
            {
                _slots[index] = new ItemSlotDura(item);
                return numberitem - 1;
            }
            return -1;
        }
        
        public  bool AddItem2(ItemSlot itemSlot)
        {
            if (!CanAcceptItem(itemSlot.Item, itemSlot is ItemSlotStack ? (itemSlot as ItemSlotStack).NumberItem : 1))
            {
                EventManger<string>.RaiseEvent("ShowNotifycation","Kho đồ đã đầy");
                return false;
            }
            switch (itemSlot)
            {
                case ItemSlotStack:
                    var itemStack = itemSlot as ItemSlotStack;
                    var numberadd = itemStack.NumberItem;
                    AddfollowReQuest(itemStack.Item, numberadd);
                    break;
                case ItemSlotDura :
                    var index = FindIndexSlotEmTy();
                    _slots[index] = new ItemSlotDura(itemSlot as ItemSlotDura);
                    break;
                
                default:
                    return false;
                    break;
            }
            OnUpdateInventory();
            return true;
          
        }
     
        private void AddfollowReQuest(ItemObject item, int number)
        {
            while (number > 0)
            {
                var relavant = FindSlot(item);
                if (relavant != null)
                {
                    if ((relavant as ItemSlotStack).CanAddItem(number))
                    {
                        (relavant as ItemSlotStack).NumberItem += number;
                        number = 0;
                    }
                    else
                    {
                        var maxStack = (item as IStackAble).MaxStack;
                        var numberaddtofull =   maxStack -  (relavant as ItemSlotStack).NumberItem;
                        (relavant as ItemSlotStack).NumberItem +=numberaddtofull;
                        number -= numberaddtofull;
                        
                    }
                }
                else
                {
                    var numberafteradd = AddFirstSlotEmty(item, number);
                    number = numberafteradd;
                }
            }
        }
        
   
        private void OnUpdateInventory()
        {
            StateChangeInventory?.Invoke();
        }
        
      
      
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        public object SaveData()
        {
            List<Itemdata> listItemSave = new List<Itemdata>();
            foreach (var slot in _slots)
            {
                if(!slot.HasItem()) continue;
               
                if (slot.Item is IStackAble)
                {
                    Itemdata newItem = new Itemdata(slot.ID, (slot as ItemSlotStack).NumberItem,0);
                    listItemSave.Add(newItem);
                }
                else
                {
                    Itemdata newItem = new Itemdata(slot.ID, 0,(slot as ItemSlotDura).Durability);
                    listItemSave.Add(newItem);
                }
            }
            return listItemSave;
        }
        public void LoadData(object state)
        {
            var listItemsave = JsonConvert.DeserializeObject<List<Itemdata>>(state.ToString());
            for (int i = 0; i < listItemsave.Count; i++)
            {

                var item = ItemObject.getItemByID(listItemsave[i].ID);
                if (item is IStackAble)
                {
                    _slots[i] = new ItemSlotStack(item, listItemsave[i].Quantity);
                }
                else
                {
                    _slots[i] = new ItemSlotDura(item,listItemsave[i].Durability);
                }
            }
        }

    }
}


