

namespace InventorySystem
{
    public class ItemSlotDura : ItemSlot
    {
        private int _durability;
        public int Durability
        {
            get => _durability;
            set
            {
                _durability = value;
                OnStateChange();
             
            }
        }
        public ItemSlotDura(ItemObject itemObject, int durability): base(itemObject)
        {
            Durability = durability;
        }

        public ItemSlotDura(ItemObject itemObject) : base(itemObject)
        {
            Durability = (itemObject as AgriculturalObject).Durability;
        }
        public ItemSlotDura(ItemSlotDura itemObject) : base(itemObject)
        {
            Durability = itemObject.Durability;
        }

        public override void SetEmty()
        {
            base.SetEmty();
            Durability = 0;
        }

        public override  void UseItem()
        {
            Durability -= (Item as AgriculturalObject).ReduceDura;
            if(_durability <=0) SetEmty();
        }
    }
}

