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
            return _slots.Where(slot => slot.HasItem() && slot.Item.ItemInfor is ItemInvenSo) .ToList();;
        }
        public List<ItemSlot> GetItemClothesInBag()
        {
            return _slots.Where(slot => slot.Item is ItemClothes) .ToList();
        }
        public void OnChangeBag()
        {
            StateChangeBags?.Invoke();
        }
        public void OnChangeHand()
        {
             //StateChangeHand?.Invoke(HandItem);
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
                Itemdata data = new Itemdata();
                switch (slot.Item)
                {
                    case ItemStack stack:
                        data = new Itemdata(stack.ID, stack.NumberItem, 0);
                        break;
                    case ItemDura dura:
                        data = new Itemdata(dura.ID, 0, dura.CurDurability);
                        break;
                    default:
                        data = new Itemdata(slot.Item.ID, 0, 0);
                        break;
                    
                    //After that, there are more types of items to add later
                }
                listItemSave.Add(data);
            }
            return listItemSave;
        }
        public void LoadData(object state)
        {
            var listItemsave = JsonConvert.DeserializeObject<List<Itemdata>>(state.ToString());
            for (int i = 0; i < listItemsave.Count; i++)
            {
                var item =  Item_SO.getItemByID(listItemsave[i].ID);
                _slots[i].AsignItem(item, listItemsave[i].Quantity, out var nu);
            }
        }
        
        

    }

}

