

using System.Linq;
using UnityEngine;

namespace  InventorySystem
{
    public abstract class StoreItems :  MonoBehaviour
    {
        [SerializeField] protected ItemSlot[] _slots;
        [SerializeField] private  int _size = 30;
        public  ItemSlot[] Slot=> _slots;
        public int Size => _size;


        protected  void Awake()
        {
            InstiateSlots();
        }

        private void InstiateSlots()
        {
            print(_size);
             _slots = new ItemSlot[_size];
            for (int i = 0; i < _size; i++)
            {
                print(i);
                if (_slots[i] == null)
                {
                    _slots[i] = new ItemSlot();
                }
               
            }
            print(_slots.Length);
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
            return true;
        }
        //Add vào 1 slot Emty nếu đó là ItemDura thì add mới, nếu là SlotStack thì kiểm tra xem nếu số lượng add vào nhở hơn slotstack thì add vaod với số lươg đó
        //nếu lớn hơn thì sẽ tính phần dư thừa và tiếp tục add tiếp
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
                    return false; 
            }
            return true;
          
        }
        
        // Add thêm Item nếu là itemDura thì sẽ tìm slot Emty để add , nếu là itemStack thì sẽ nhận vào số lượng add , kiểm tra tra trong inven
        //có itemstack nào có thể add thêm số lượng đó không . Nếu itemstack đó sau khi add thêm số lượng khi đã đầy stack nhưng vẫn còn thừa số lượng add 
        //và vẫn còn slot emty thì tạo mơí slot và add vào
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
        
        
        

    }
    
    
    
   
}


