
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace InventorySystem
{
    public class UI_OptionItem : AbsCheckOutSide
    {
        [SerializeField] private Button _btn_GetItem;
        [SerializeField] private UI_Inventoryslot _uiInventoryslot;
        [SerializeField] private InventoryController _inventoryController;
        public  void Start()
        {
            _btn_GetItem = transform.GetComponentInChildren<Button>();
            _btn_GetItem.onClick.AddListener(GetItemClick);
        }
        public void GetItemClick()
        {
            _inventoryController.ItemInventoryToBag(_uiInventoryslot);
            gameObject.SetActive(false);
        }
        
        public void ShowOption(UI_Inventoryslot uiInventoryslot)
        {
            _uiInventoryslot = uiInventoryslot;
            if (gameObject.activeSelf)
            {
                gameObject.SetActive(false);
                RemoveClick();
                return;
            }
            gameObject.SetActive(true);
            regisclick();
        }

        protected override void Click(InputAction.CallbackContext obj)
        {
           if(!_isOutSide) return;
           _uiInventoryslot.Slot.IsActive = false;
           gameObject.SetActive(false);
        }
    }

}
