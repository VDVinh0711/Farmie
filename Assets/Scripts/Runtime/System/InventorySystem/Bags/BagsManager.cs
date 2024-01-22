﻿using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;


using Newtonsoft.Json;
using Unity.Services.Analytics;

namespace InventorySystem
{
    public class BagsManager : Singleton<BagsManager> , ISaveSystem
    {
        [SerializeField] protected ItemSlot[] _slots;
        [SerializeField] protected List<ItemSlot> _slotItem;
        [SerializeField] protected  int _size = 8;
        [SerializeField] private ItemSlot _handItem;
        public ItemSlot HandItem=> _handItem;
        public  ItemSlot[] Slot=> _slots;
        public int Size => _size;   
        public event Action StateChangeBags;
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
            AddfollowReQuest(item, numberitem);
            OnUpdateBag();
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
                    AddfollowReQuest(itemStack.Item,numberadd);
                    break;
                case ItemSlotDura :
                    var index = FindIndexSlotEmTy();
                    _slots[index] = new ItemSlotDura(itemSlot as ItemSlotDura);
                    break;
                
                default:
                    return false;
                    break;
            }
           OnUpdateBag();
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
        public void RemoveItem(ItemSlot itemSlot, int quantity)
        {
            foreach (var slot in _slots)
            {
                if (slot == itemSlot)
                {
                    if (slot is ItemSlotStack)
                    {
                        (slot as ItemSlotStack).PreviousItem(quantity);
                    }
                }
            }
        }
        public void RemoveItem(ItemSlot itemSlot)
        {
            foreach (var slot in _slots)
            {
                if (slot == itemSlot)
                { 
                    slot.SetEmty();
                }
            }
        }
        public List<ItemSlot> GetListSLotItem()
        {
            _slotItem = new List<ItemSlot>();
            foreach (var slot in _slots)
            {
                if(slot.Item is ItemInvenObject)
                    _slotItem.Add(slot);
            }
            return _slotItem;
        }
        public void SwapItem(  ref ItemSlot item1,  ref ItemSlot item2)
        {
            ItemSlot temp = new ItemSlot();
            temp = item1;
            item1 = item2;
            item2 = temp;
        }
        
        public ItemSlot GetItemByIndex(int index)
        {
            ItemSlot temp = new ItemSlot();
            SwapItem(ref _slots[index],ref temp);
            return temp;
        }
        public ItemSlot GetItemByIndex(int index, int quantity)
        {
            if (!( _slots[index] is ItemSlotStack)) return null;
            ItemSlot temp = new ItemSlotStack(_slots[index].Item, quantity);
            (_slots[index] as ItemSlotStack).NumberItem -= quantity;
            return temp;
        }
        public void InventoHand(int index)
        {
            if (!_slots[index].HasItem()) return;
            if(!(_slots[index].Item is EquidmentObject)) return;    
            SwapItem(ref _slots[index], ref _handItem);
            OnUpdateBag();
        }
        public void HandtoInventory()
        {
            if(!_handItem.HasItem()) return;
            var index = FindIndexSlotEmTy();
            if (_handItem is ItemSlotStack)
            {
                _slots[index] = new ItemSlotStack(_handItem.Item, (_handItem as ItemSlotStack).NumberItem);
            }
            else
            {
                _slots[index] = new ItemSlotDura(_handItem as ItemSlotDura);
            }
            _handItem.SetEmty();
            OnUpdateBag();
        }
        
         private void OnUpdateBag()
        {
            StateChangeBags?.Invoke();
        }
         
        public object SaveData()
        {
            HandtoInventory();
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
                var item =  ItemObject.getItemByID(listItemsave[i].ID);
                if (item is IStackAble)
                {
                    _slots[i] = new ItemSlotStack(item,listItemsave[i].Quantity);
                }
                else
                {
                    _slots[i] = new ItemSlotDura(item, listItemsave[i].Durability);
                }
            }
        }
        
        

    }

}

