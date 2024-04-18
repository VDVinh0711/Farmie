
using System;
using UnityEngine;

using UnityEngine.UI;

namespace InventorySystem
{
    public class UI_OptionItemInven : MonoBehaviour
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
        
        public void Togggle(UI_Inventoryslot uiInventoryslot)
        {
            _uiInventoryslot = uiInventoryslot;
            if (gameObject.activeSelf)
            {
                HideOption();
                return;
            }
            ShowOption();
            
        }

        public void ShowOption()
        {
            gameObject.SetActive(true);
        }

        public void HideOption()
        {
            gameObject.SetActive(false);
        }
      
    }

}
