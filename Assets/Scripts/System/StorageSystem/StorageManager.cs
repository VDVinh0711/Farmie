
using System;
using UnityEngine;
using System.Linq;



namespace InventorySystem
{
    public class StorageManager : MonoBehaviour
    {
        [SerializeField] protected ItemSlot[] _slots;
        [SerializeField] protected int _size;
        public  ItemSlot[] Slot=> _slots;
        public int Size => _size;   
        
        //Value initialization
        private void AdjustInven()
        {
            _slots = new ItemSlot[_size];
            for (int i = 0; i < _size; i++)
            {
                _slots[i] = new ItemSlot();
            }
        }
        private void OnValidate()
        {
            AdjustInven();
        }
        
        //Check Inventory is full
        public bool ISFull()
        {
            return  _slots.Count(slot => slot.HasItem()) >= _size;
        }
        
        //Find Slot can add Stacl
        private ItemSlot FindSlotStackToAdd(Item item)
        {
            var itemAdd = _slots.FirstOrDefault(x => x.HasItem() && x.Item.ID == item.ID && x.Item is ItemStack itemSlot && itemSlot.CanStackAble());
            return itemAdd;
        }
        
        //Find Slot emty to add
        private int FindIndexSlotEmTy()
        {
            var slot = _slots.FirstOrDefault(slot => !slot.HasItem());
            var slotIndex = slot == null ? -1 : Array.IndexOf(_slots, slot);
            return slotIndex;
        }
        
        //Check Invntory Can't AddItem
        public bool CanAcceptItem(Item item, int numberitem = 1)
        {
            int availableEmptySlots = 0;
            foreach (var slot in _slots)
            {
                if (!slot.HasItem())
                {
                    availableEmptySlots++;
                }
            }

            if (item is ItemStack itemStack)
            {

                var relevantSlot = FindSlotStackToAdd(item);
                if (ISFull())
                {
                    if (relevantSlot != null)
                    {
                        return relevantSlot != null && (relevantSlot.Item as ItemStack).CanAddItem(numberitem);
                    }
                }
                   
                else
                {
                    // Calculate required slots for additional items
                    int numberAdded = 0;
                    if (relevantSlot != null)  numberAdded = relevantSlot.Item is ItemStack stack ? stack.NumberItem : 0;
                    float requiredSlots = (numberitem - numberAdded) / itemStack.SizeStack;
                    if (requiredSlots < availableEmptySlots) return true;
                }
            }
            else
            {
                if (!ISFull() && numberitem <= availableEmptySlots)  return true;
            }
            return false;
        }
        
        //Add Item
        
        public  bool AddItem(Item item, int numberitem = 1)
        {
            
            if (!CanAcceptItem(item, numberitem))
            {
                EventManger<string>.RaiseEvent("ShowNotifycation","Kho đồ đã đầy");
                return false;
            }
            AddfollowReQuest(item, numberitem);
            AcitoneChangeSomething();
            return true;
        }
        private void AddFirstSlotEmty(Item item , int numberAdd , out int renumber)
        {
            int index = FindIndexSlotEmTy();
            renumber = 0;
            if (index == -1) return;
            _slots[index].AsignItem(item.ItemInfor , numberAdd , out  int requantity);
            renumber = requantity;

        }
       
        
        //In addition to a large number of items, it will add items one by one to the cells,
        //if added to one cell but there are still leftover items, it will add to another cell,
        //so on until the item runs out
        private void AddfollowReQuest(Item item, int numberAdd)
        {
            
            while (numberAdd > 0)
            {
                var relavant = FindSlotStackToAdd(item);
                if (relavant != null )
                {
                    if(!(relavant.Item is ItemStack itemStack)) return;
                    print(numberAdd);
                    itemStack.AddStack(numberAdd,  out int renumber);
                    numberAdd -= renumber;
               
                }
                else
                {
                   AddFirstSlotEmty(item, numberAdd , out int renumber);
                    numberAdd = renumber;
                }
            }
        }
        public void RemoveItem(Item item, int quantity)
        {
            foreach (var slot in _slots)
            {
                if (slot.Item.ID != item.ID) continue;
                if (slot.Item is ItemStack) (slot.Item as ItemStack).PreviousItem(quantity);
                else slot.SetEmty();
            }
        }                                          
        protected virtual void AcitoneChangeSomething()
        {
            
        }
        public int CountItem(string ID)
        {
            var result = 0;
            foreach (var slot in _slots)
            {   
                if(!slot.HasItem()) continue;
                if(slot.Item.ID != ID) continue;
                switch (slot.Item)
                {
                    case ItemStack itemSlotStack:
                        result += itemSlotStack.NumberItem;
                        break;
                    default:
                        result += 1;
                        break;
                }
            }
            return result;
        }
        public bool IsItemExits(string idItem)
        {
            var itemExits =    _slots.FirstOrDefault(x => x.Item.ID.Equals(idItem));
            if (itemExits == null) return false;
            return true;
        }
}

}
