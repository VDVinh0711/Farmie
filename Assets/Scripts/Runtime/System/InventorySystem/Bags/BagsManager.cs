using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;


using Newtonsoft.Json;
namespace InventorySystem
{
    public class BagsManager : Inventory,ISaveSystem
    {
        [SerializeField] private ItemSlot _handItem;
        public static BagsManager Instance;
        public ItemSlot HandItem=> _handItem;
        public event Action StateChange;


        protected override void Awake()
        {
            if(Instance == this) return;
            Instance = this;
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
         private void OnUpdateBag()
        {
           
            StateChange?.Invoke();
        }

        
        public object SaveData()
        {
            HandtoInventory();
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

