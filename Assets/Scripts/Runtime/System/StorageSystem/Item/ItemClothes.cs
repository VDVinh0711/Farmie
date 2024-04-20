using System;
using UnityEngine.U2D.Animation;
namespace  InventorySystem
{
    [Serializable]
    public class ItemClothes : Item
    {
        private SpriteLibraryAsset _spriteLibraryAsset;
        private CLothesType _type;
        public CLothesType Type => _type;
        public SpriteLibraryAsset SpriteLibraryAsset
        {
            get => _spriteLibraryAsset; 
            set
            {
                _spriteLibraryAsset = value;
            }
        }

        
        
        public ItemClothes(ClothesItem_SO itemInforClothes): base(itemInforClothes)
        {
            _spriteLibraryAsset = itemInforClothes.SpriteLibraryAsset;
            _type = itemInforClothes.Type;
        }
        public ItemClothes(ItemClothes itemClothes) : base(itemClothes)
        {
            _spriteLibraryAsset = itemClothes.SpriteLibraryAsset;
            _type = itemClothes.Type;
        }

        public override void UseItem()
        {
            throw new NotImplementedException();
        }

        public override void SetEmty()
        {
            base.SetEmty();
        }

        public override Item ItemClone()
        {
            return new ItemClothes(this);
        }
    }
}

