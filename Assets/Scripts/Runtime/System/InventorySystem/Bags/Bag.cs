using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;



namespace InventorySystem
{
    public class Bag : StorageManager , ISaveData
    {
        
        

        [SerializeField] private BagController _bagController;
        public BagController BagController => _bagController;
        public event Action<ItemSlot> StateChangeHand; 
        public ItemSlot HandItem=> _bagController.HandItem;
        public event Action StateChangeBags;
        
        
         
      
        public List<ItemSlot> GetListSLotItem()
        {
            return _slots.Where(slot => slot.Item is ItemInvenSo) .ToList();;
        }
        public List<ItemSlot> GetItemClothesInBag()
        {
            return _slots.Where(slot => slot.Item is ClothesItem_SO) .ToList();
        }
        public ItemSlot GetItemByItemOBJ(Item_SO itemSlot)
        {
            return _slots.FirstOrDefault(x => x.Item == itemSlot);
        }
        public void OnChangeBag()
        {
            StateChangeBags?.Invoke();
        }
        public void OnChangeHand()
        {
             StateChangeHand?.Invoke(HandItem);
        }
        protected override void AcitoneChangeSomething()
        {
            OnChangeBag();
        }

        

        public object SaveData()
        {
            _bagController.IteminHandtoBag();
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
                    Itemdata newItem = new Itemdata(slot.ID, 0,(slot as ItemSlotDura).CurDurability);
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
                var item =  Item_SO.getItemByID(listItemsave[i].ID);
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

