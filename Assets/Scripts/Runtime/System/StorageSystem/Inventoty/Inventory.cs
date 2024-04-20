using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Player;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory :  StorageManager,ISaveData
    {
        public event Action Changeinventory;

        private PlayerManager _playerManager;
        public PlayerManager PlayerManager => _playerManager;

        public void AssignPlayer(PlayerManager playerManager)
        {
            _playerManager = playerManager;
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


