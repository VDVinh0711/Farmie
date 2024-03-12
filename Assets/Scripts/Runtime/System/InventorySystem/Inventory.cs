using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory :  MonoBehaviour,ISaveData
    {
        public event Action Changeinventory;
        [SerializeField] private ItemSlot[] _slots;
        [SerializeField] private  int _size = 30;
        public  ItemSlot[] Slot=> _slots;
        public int Size => _size;
        protected  void Awake()
        {
            InstiateSlots();
        }

        public void NotifyChangeInventory()
        {
            Changeinventory?.Invoke();
        }

        private void InstiateSlots()
        {
            _slots = new ItemSlot[_size];
            for (int i = 0; i < _size; i++)
            {
                if (_slots[i] == null)
                {
                    _slots[i] = new ItemSlot();
                }
               
            }
        }

        public bool ISFull()
        {
            return  _slots.Count(slot => slot.HasItem()) >= _size;
        }
        private ItemSlot FindSlotStackToAdd(ItemObject itemObject )
        {
           
            var item = _slots.FirstOrDefault(x =>x.Item == itemObject && x is ItemSlotStack itemSlot && itemSlot.CanStackAble());
            return item;
        }
        protected  int FindIndexSlotEmTy()
        {
            for (int i = 0; i < _size; i++)
            {
                if (!_slots[i].HasItem()) return i;
            }
            return -1;
        }
        public bool CanAcceptItem(ItemObject item , int numberitem)
        {
            int availableEmptySlots = 0;
            foreach (var slot in _slots)
            {
                if (!slot.HasItem())
                {
                    availableEmptySlots++;
                }
            }

            if (item is IStackAble itemStack)
            {
                var relevantSlot = FindSlotStackToAdd(item) as ItemSlotStack;

                if (ISFull())
                {
                    if (relevantSlot != null && relevantSlot.CanAddItem(numberitem))
                    {
                        return true;
                    }
                }
                else
                {
                    // Calculate required slots for additional items
                    int numberAdded = relevantSlot?.NumberItem ?? 0;
                    float requiredSlots = (numberitem - numberAdded) / itemStack.MaxStack;

                    if (requiredSlots < availableEmptySlots)
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (!ISFull() && numberitem <= availableEmptySlots)
                {
                    return true;
                }
            }
            return false;
        }
        public virtual  bool AddItem(ItemObject item, int numberitem)
        {
            if (!CanAcceptItem(item, numberitem))
            {
                EventManger<string>.RaiseEvent("ShowNotifycation","Kho đồ đã đầy");
                return false;
            }
            var numberadd = numberitem;
            AddfollowReQuest(item, numberitem);
            NotifyChangeInventory();
            return true;
        }
        // Add to an empty slot
        // If it is an itemDura, add it as a new item.
        // If it is a slotStack, check if the number to add is less than the size of the slotStack.
        // If it is, add the number to the slotStack.
        // If it is larger, calculate the excess and continue adding items to the slotStack until the number is exhausted
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

                if (item is IDurability)
                {
                    _slots[index] = new ItemSlotDura(item);
                    return numberitem - 1;
                }
                else
                {
                    _slots[index] = new ItemSlot(item);
                    return numberitem - 1;
                }
            }
            return -1;
        }
        public virtual  bool AddItem(ItemSlot itemSlot)
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
                    var index2 = FindIndexSlotEmTy();
                    _slots[index2] = new ItemSlot(itemSlot);
                    break;
                    
            }
            return true;
          
        }
        // Add an item
        // If it is an itemDura, it will find an empty slot to add it to.
        // If it is an itemStack, it will receive the number to add.
        // It will check if there is another itemStack in the inventory that can be added to the number.
        // If the itemStack is full after adding the number but still has the remaining number,
        // and there are still empty slots, it will create a new slot and add the remaining number to it.
        private void AddfollowReQuest(ItemObject item, int number)
        {
            while (number > 0)
            {
                var relavant = FindSlotStackToAdd(item);
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
        public object SaveData()
        {
            List<Itemdata> listItemSave = new List<Itemdata>();
            foreach (var slot in _slots)
            {
                if (slot == null) continue;
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


