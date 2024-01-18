using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory : MonoBehaviour,ISaveSystem
{
        [SerializeField] protected ItemSlot[] _slots;
        [SerializeField] protected List<ItemSlot> _slotItem;
        [SerializeField] protected  int _size = 30;
        public static Inventory Instance;
        public  ItemSlot[] Slot=> _slots;
        public int Size => _size;   
        public event Action StateChange;
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
            while (numberadd > 0)
            {
                var relavant = FindSlot(item);
                if (relavant != null)
                {
                    print(relavant.Item.name);
                    if ((relavant as ItemSlotStack).CanAddItem(numberadd))
                    {
                        (relavant as ItemSlotStack).NumberItem += numberadd;
                        numberadd = 0;
                    }
                    else
                    {
                        var maxStack = (item as IStackAble).MaxStack;
                        var numberaddtofull =   maxStack -  (relavant as ItemSlotStack).NumberItem;
                        (relavant as ItemSlotStack).NumberItem +=numberaddtofull;
                        numberadd -= numberaddtofull;
                        
                    }
                }
                else
                {
                    var numberafteradd = AddFirstSlotEmty(item, numberadd);
                    numberadd = numberafteradd;
                }
            }
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

        public void AddSlotEmtybyIndex(ItemSlot itemSlot, int index)
        {
            if (itemSlot is ItemSlotStack)
            {
                _slots[index] = new ItemSlotStack(itemSlot as ItemSlotStack);
            }
            else
            {
                _slots[index] = new ItemSlotDura(itemSlot as ItemSlotDura);  
            }
            OnUpdateInventory();
        }

        public void RemoveItem(int index)
        {
            _slots[index].SetEmty();
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
                    else
                    {
                        slot.SetEmty();
                    }
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
        private void OnUpdateInventory()
        {
            StateChange?.Invoke();
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        public object SaveData()
        {
            List<Itemdata> listItemSave = new List<Itemdata>();
            foreach (var slot in _slots)
            {
                if(!slot.HasItem()) continue;
               
                if (slot.IsstackAble)
                {
                    Itemdata newItem = new Itemdata(slot.ID, (slot as ItemSlotStack).NumberItem,0,slot.IsstackAble);
                    listItemSave.Add(newItem);
                }
                else
                {
                    Itemdata newItem = new Itemdata(slot.ID, 0,(slot as ItemSlotDura).Durability,slot.IsstackAble);
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
                if (listItemsave[i].IsStackABle)
                {
                    _slots[i] = new ItemSlotStack(ItemObject.getItemByID(listItemsave[i].ID),
                        listItemsave[i].Quantity);
                }
                else
                {
                    _slots[i] = new ItemSlotDura(ItemObject.getItemByID(listItemsave[i].ID),
                        listItemsave[i].Durability);
                }
            }
        }

    }
}


