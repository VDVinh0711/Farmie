
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
        public bool ISFull()
        {
            return  _slots.Count(slot => slot.HasItem()) >= _size;
        }
        private ItemSlot FindSlotStackToAdd(Item_SO itemSo)
        {
            var item = _slots.FirstOrDefault(x =>x.Item == itemSo && x is ItemSlotStack itemSlot && itemSlot.CanStackAble());
            return item;
        }
        private int FindIndexSlotEmTy()
        {
            for (int i = 0; i < _size; i++)
            {
                if (!_slots[i].HasItem()) return i;
            }
            return -1;
        }
        public bool CanAcceptItem(Item_SO item , int numberitem)
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
        public  bool AddItem(Item_SO item, int numberitem)
        {
            if (!CanAcceptItem(item, numberitem))
            {
                EventManger<string>.RaiseEvent("ShowNotifycation","Kho đồ đã đầy");
                return false;
            }
            var numberadd = numberitem;
            AddfollowReQuest(item, numberitem);
            AcitoneChangeSomething();
            return true;
        }
        private int AddFirstSlotEmty(Item_SO item , int numberitem)
        {
            int index = FindIndexSlotEmTy();
            if (index == -1) return -1;
            switch (item)
            {
                case IStackAble  stackAble :
                    int maxStack = stackAble.MaxStack;
                    if (maxStack > numberitem) _slots[index] = new ItemSlotStack(item, numberitem);
                    else
                    {
                        _slots[index] = new ItemSlotStack(item, maxStack);
                        return numberitem - maxStack; 
                    }
                    break;
                case AgriculturalSo :
                    _slots[index] = new ItemSlotDura(item);
                    return numberitem - 1; 
                    break;
                case ClothesItem_SO itemclothes :
                    _slots[index] = new ItemSlotClothes(itemclothes);
                    return numberitem - 1;
                    break;
                default:
                    _slots[index] = new ItemSlot(item);
                    return numberitem - 1; 
                    break;
            }
            return -1;
        }
        public  bool AddItem(ItemSlot itemSlot)
        {
            if (itemSlot == null) return false;
            if (!CanAcceptItem(itemSlot.Item, itemSlot is ItemSlotStack ? (itemSlot as ItemSlotStack).NumberItem : 1))
            {
                EventManger<string>.RaiseEvent("ShowNotifycation","Kho đồ đã đầy");
                return false;
            }
            var index = FindIndexSlotEmTy();
            switch (itemSlot)
            {
                case ItemSlotStack:
                    var itemStack = itemSlot as ItemSlotStack;
                    var numberadd = itemStack.NumberItem;
                    AddfollowReQuest(itemStack.Item,numberadd);
                    break;
                case ItemSlotDura :
                    _slots[index] = new ItemSlotDura(itemSlot as ItemSlotDura);
                    break;
                case ItemSlotClothes:
                    _slots[index] = new ItemSlotClothes(itemSlot as ItemSlotClothes);
                    break;
                case ItemSlot :
                    _slots[index] = new ItemSlot(itemSlot);
                    break;
                default:
                    return false;
            }

            AcitoneChangeSomething();
            return true;
        }
        private void AddfollowReQuest(Item_SO item, int number)
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
        protected virtual void AcitoneChangeSomething()
        {
            
        }
}

}
