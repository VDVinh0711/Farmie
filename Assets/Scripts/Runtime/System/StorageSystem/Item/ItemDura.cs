

using System;

namespace InventorySystem
{
    [Serializable]
    public class ItemDura : Item
    {
        private int _currentDura;
        public int CurDurability
        {
            get => _currentDura;
            set
            {
                _currentDura = value >= 0 ? value : 0;
            }
        }
        private int _reduceDura => (_itemInfor as AgriculturalSo).ReduceDura;
        public ItemDura(Item_SO itemSo, int curDurability): base(itemSo)
        {
            CurDurability = curDurability;
        }
        public ItemDura(Item_SO itemSo) : base(itemSo)
        {
            CurDurability = (itemSo as AgriculturalSo).MaxDurability;
        }
        public ItemDura(ItemDura itemObject) : base(itemObject)
        {
            CurDurability = itemObject.CurDurability;
        }

        public override void SetEmty()
        {
            _currentDura = 0;
            base.SetEmty();
        }

        public override Item ItemClone()
        {
            return new ItemDura(this);
        }

        public override  void UseItem()
        {
            CurDurability -= _reduceDura;
            if(CurDurability <=0) SetEmty();
        }
        public ItemDura GetItemSlotDure()
        {
            ItemDura item = new ItemDura(this.ItemInfor, this.CurDurability);
            this.SetEmty();
            return item;
        }
    }
}

