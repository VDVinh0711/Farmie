

namespace InventorySystem
{
    public class ItemSlotDura : ItemSlot
    {
        
       
        public int CurDurability
        {
            get =>  (_item as AgriculturalSo).CurrentDura;
            set
            {
                (_item as AgriculturalSo).CurrentDura = value;
                OnStateChange();
            }
        }
        private int _currentDurability;
        public ItemSlotDura(Item_SO itemSo, int curDurability): base(itemSo)
        {
            CurDurability = curDurability;
        }
        public ItemSlotDura(Item_SO itemSo) : base(itemSo)
        {
            CurDurability = (itemSo as AgriculturalSo).MaxDurability;
        }
        public ItemSlotDura(ItemSlotDura itemObject) : base(itemObject)
        {
            CurDurability = itemObject.CurDurability;
        }

        public override void SetEmty()
        {
            base.SetEmty();
            CurDurability = 0;
        }
        public override  void UseItem()
        {
            CurDurability -= (Item as AgriculturalSo).ReduceDura;
            if(CurDurability <=0) SetEmty();
        }
        public ItemSlotDura GetItemSlotDure()
        {
            ItemSlotDura item = new ItemSlotDura(this.Item, this.CurDurability);
            this.SetEmty();
            return item;
        }
    }
}

