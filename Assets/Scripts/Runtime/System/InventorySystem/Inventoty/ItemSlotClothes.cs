using System;
using UnityEngine.U2D.Animation;
namespace  InventorySystem
{
    [Serializable]
    public class ItemSlotClothes : ItemSlot
    {
        private SpriteLibraryAsset _spriteLibraryAsset;
        private CLothesType _type;
        public CLothesType Type => _type;
        public SpriteLibraryAsset SpriteLibraryAsset
        {
            get { return _spriteLibraryAsset; }
            set
            {
                _spriteLibraryAsset = value;
            }
        }

        public ItemSlotClothes(ClothesItem_SO itemClothes): base(itemClothes)
        {
            _spriteLibraryAsset = itemClothes.SpriteLibraryAsset;
            _type = itemClothes.Type;
        }
        public ItemSlotClothes(ItemSlotClothes itemSlotClothes) : base(itemSlotClothes)
        {
            _spriteLibraryAsset = itemSlotClothes.SpriteLibraryAsset;
            _type = itemSlotClothes.Type;
        }
        public override void SetEmty()
        {
            base.SetEmty();
            _spriteLibraryAsset = null;
        }
    }
}

