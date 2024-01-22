


using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace InventorySystem
{
    public class UI_BagSlots :UI_Slots
    {

        #region BackUp Old Version

        /* #region Prop
        [SerializeField] protected InventorySlot _slot;
        [SerializeField] public int _indexOfSlot;
        [SerializeField] private UI_DisplayItem _uiItem;
        [SerializeField] private UI_Bags _uiBags;
        public InventorySlot Slot => _slot;
        public event Action<string,string> showDesEvent;
        protected FarmInputAction _farmInputAction;
        [SerializeField] protected bool isPressShift = false;
        #endregion
        
        private void Start()
        {
            _uiBags = FindObjectOfType<UI_Bags>();
            _uiItem = transform.GetComponentInChildren<UI_DisplayItem>();
            _farmInputAction = new FarmInputAction();
            _farmInputAction.Enable();
            _farmInputAction.InteracPlayer.ShiftHold.performed += ShiftPress;
            _farmInputAction.InteracPlayer.ShiftHold.canceled += ShiftOut;
        }
        
        public void Display(InventorySlot item)
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
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            string name = _slot.HasItem() ? _slot.Item.name : " ";
            /*var des = GameMultiLang.Instance.currentlang.Equals("vn")
                ? _slot.Item.DescriptionVN
                : _slot.Item.DescriptionEN;*/
         /**   string description = _slot.HasItem() ?  "đâsd" : " ";
            showDesEvent?.Invoke(name,description);
        }
        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (isPressShift)
            {
                BagsManager.Instance.InventoHand(_indexOfSlot);
                return;
            }
            _slot.IsActive = true;
            _uiBags.UIItemBagOption.ShowOption(this);
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            showDesEvent?.Invoke("","");
        }
        
        public int getIndexItem()
        {
            return _indexOfSlot;
        }

        public InventorySlot getData()
        {
            return _slot;
        }

        private void ShiftPress(InputAction.CallbackContext obj)
        {
            print(obj);
            isPressShift = true;
        }

        private void ShiftOut(InputAction.CallbackContext obj)
        {
            print(obj);
            isPressShift = false;
        }*/

        #endregion
       
         [SerializeField] private UI_Bags _uiBags;
         protected override void Start()
         {
             base.Start();
             _uiBags = FindObjectOfType<UI_Bags>();
         }

         public override void OnPointerClick(PointerEventData eventData)
         {
             base.OnPointerClick(eventData);
             if(!_slot.HasItem()) return;
             if (isPressShift)
             {
                 //BagsManager.Instance.InventoHand(_indexOfSlot);
                 Crafting.Instance.AddItemSlot(BagsManager.Instance.GetItemByIndex(_indexOfSlot));
                 return;
             }
             _slot.IsActive = true;
             _uiBags.UIItemBagOption.ShowOption(this);
         }
    }
}

