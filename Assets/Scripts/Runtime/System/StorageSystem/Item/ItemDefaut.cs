

using System;

namespace InventorySystem
{
    [Serializable]
    public class ItemDefaut : Item
    {
    
        
        public ItemDefaut(Item_SO itemInfor) : base(itemInfor)
        {
        }

        public ItemDefaut(Item item) : base(item)
        {
        }

        public override void UseItem()
        {
            throw new System.NotImplementedException();
        }

        public override Item ItemClone()
        {
            return new ItemDefaut(this);
        }
    }
}


