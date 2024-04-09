using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory :  StorageManager,ISaveData
    {
        public event Action Changeinventory;


        private void Awake()
        {
            print(this.gameObject.name);
        }

        protected override void AcitoneChangeSomething()
        {
            NotifyChangeInventory();
        }
        public void NotifyChangeInventory()
        {
            Changeinventory?.Invoke();
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

                var item = Item_SO.getItemByID(listItemsave[i].ID);
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


