using System;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace InventorySystem
{
    public abstract class UI_Slots : MonoBehaviour,IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        #region Prop
        [SerializeField] protected ItemSlot _slot;
        [SerializeField] public int _indexOfSlot;
        [SerializeField] private UI_DisplayItem _uiItem;
        public ItemSlot Slot => _slot;
        public event Action<string,string> showDesEvent;
        protected FarmInputAction _farmInputAction;
        [SerializeField] protected bool isPressShift = false;

        //private UI_Inventory _uiInventory;
        #endregion
        
        
        protected virtual void Start()
        {
            _uiItem = transform.GetComponentInChildren<UI_DisplayItem>();
            _farmInputAction = new FarmInputAction();
            _farmInputAction.Enable();
            _farmInputAction.InteracPlayer.ShiftHold.performed += ShiftPress;
            _farmInputAction.InteracPlayer.ShiftHold.canceled += ShiftOut;
        }
        
        public void Display(ItemSlot item)
        {
            if (item == null) return;
            _slot = item;
            if(_uiItem == null) _uiItem = transform.GetComponentInChildren<UI_DisplayItem>();
            _uiItem.UpdateView(_slot);
        }
        
        
        public void AssighIndex(int index)
        {
            _indexOfSlot = index;
        }
     
        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            
            string name = _slot.HasItem() ? _slot.Item.name : " ";
            if(!_slot.HasItem()) return;
            var des = GameManager.Instance.GameMultiLang.currentlang.Equals("vn") ? _slot.Item.DescriptionVN : _slot.Item.DescriptionEN;
            string description = _slot.HasItem() ?  des : " ";
            showDesEvent?.Invoke(name,description);
        }
        public virtual void OnPointerClick(PointerEventData eventData)
        {
           if(!_slot.HasItem()) return;
        }
        public virtual void OnPointerExit(PointerEventData eventData)
        {
            showDesEvent?.Invoke("","");
        }
        public int getIndexItem()
        {
            return _indexOfSlot;
        }

        public ItemSlot getData()
        {
            return _slot;
        }

        private void ShiftPress(InputAction.CallbackContext obj)
        {
           
            isPressShift = true;
        }

        private void ShiftOut(InputAction.CallbackContext obj)
        {
            
            isPressShift = false;
        }

    }
}

