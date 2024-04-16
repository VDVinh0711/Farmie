using System;
using Player;
using UnityEngine;
using UnityEngine.EventSystems;


namespace InventorySystem
{
    public abstract class UI_Slots : MonoBehaviour
    {
        #region Prop
        [SerializeField] protected ItemSlot _slot;
        [SerializeField] public int _indexOfSlot;
        [SerializeField] private UI_DisplayItem _uiItem;
        public ItemSlot Slot => _slot;

        #endregion
        
        protected virtual void Start()
        {
            _uiItem = transform.GetComponentInChildren<UI_DisplayItem>();
        }
        public void Display(ItemSlot item)
        {
            if (item == null) return;
            _slot = item;
            if(_uiItem == null) _uiItem = transform.GetComponentInChildren<UI_DisplayItem>();
            _uiItem.UpdateView(item);
        }
        private void OnStateChange(ItemSlot arg)
        {
            Display(_slot);
        }
        public void AssighIndex(int index)
        {
            _indexOfSlot = index;
        }
        public int getIndexItem()
        {
            return _indexOfSlot;
        }
        public void UpDateUi()
        {
            if(_uiItem == null) _uiItem = transform.GetComponentInChildren<UI_DisplayItem>();
            _uiItem.UpdateView(_slot);
        }

        /*public void AssignAndUpDateUI(Item_SO itemSo)
        {
            var temp = new ItemSlot();
            switch (itemSo)
            {
                case IStackAble itemStack :
                    temp = new ItemSlotStack(itemSo, itemStack.CurrentStack);
                    break;
                case AgriculturalSo itemdura:
                    temp = new ItemSlotDura(itemSo, itemdura.CurrentDura);
                    break;
                case ClothesItem_SO itemclothes :
                    temp = new ItemSlotClothes(itemclothes);
                    break;
                default:
                    temp = new ItemSlot(itemSo);
                    break;
                
            }

            _slot = temp;
            UpDateUi();
        }*/
    }
}

