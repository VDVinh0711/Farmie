using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


namespace InventorySystem
{
    [Serializable]
    public class UI_Inventoryslot : UI_Slots,IPointerClickHandler
    {
        
        #region Old Version
       /*#region Prop
       [SerializeField] protected InventorySlot _slot;
       [SerializeField] public int _indexOfSlot;
       [SerializeField] private UI_DisplayItem _uiItem;
       public InventorySlot Slot => _slot;
       public event Action<string,string> showDesEvent;
       protected FarmInputAction _farmInputAction;
       [SerializeField] protected bool isPressShift = false;

       private UI_Inventory _uiInventory;
       #endregion


       private void Start()
       {
           _uiInventory = FindObjectOfType<UI_Inventory>();
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
           /* string description = _slot.HasItem() ?  "đâsd" : " ";
            showDesEvent?.Invoke(name,description);
        }
        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (isPressShift)
            {
                int quantity = 1;
                if (_slot is InventorySlotStack)
                {
                    quantity = (_slot as InventorySlotStack).NumberItem;
                }
                if (!BagsManager.Instance.AddItem(_slot.Item, quantity)) return;
                Inventory.Instance.Slot[_indexOfSlot].SetEmty();
                return;
            }
            if(!_slot.HasItem()) return;
            _slot.IsActive = true;
          _uiInventory.UIOptionItem.ShowOption(this);
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
           
           [SerializeField]  private UI_Inventory _uiInventory;
           
          
           protected override void Start()
           {
               base.Start();
               _uiInventory = FindObjectOfType<UI_Inventory>();
           }

           public  void OnPointerClick(PointerEventData eventData)
           {
               if(!_slot.HasItem()) return;
               if (eventData.button == PointerEventData.InputButton.Left) {
                   _slot.IsActive = true;
                   _uiInventory.UIOptionItem.ShowOption(this);
               } 
               
           }

    }
}

