
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class UI_DisplayItem : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _quantity;
        [SerializeField] private Slider _durability_UI;
        [SerializeField] private Image _active;
        private void Start()
        {
            Getcomponent();
        }

        private void Getcomponent()
        {
            _active =transform.GetChild(0).GetComponent<Image>();
            _icon = transform.GetChild(1).GetComponent<Image>();
            _quantity = transform.GetComponentInChildren<TextMeshProUGUI>();
            _durability_UI.transform.GetComponent<Slider>();
            _durability_UI.interactable = false;
        }

        public void UpdateView(ItemSlot  slot)
        {
            slot.StateActionChange -= OnStateActionChange;
            slot.StateActionChange += OnStateActionChange;
            var hasitem = slot.HasItem();
            var isactive = slot.IsActive;
            _icon.enabled = hasitem;
            _quantity.enabled = false;
            _active.enabled = isactive;
            _durability_UI.transform.gameObject.SetActive(false);
            if (!hasitem) return;
            _icon.sprite = slot.Item.UIinInven;
            switch (slot)
            {
                case ItemSlotStack:
                    SetUpUiStack(slot as ItemSlotStack);
                    break;
                case ItemSlotDura:
                    SetUiDuraable(slot as ItemSlotDura);
                    break;
            }
            
        }
      
       
        private void SetUiDuraable(ItemSlotDura itemSlotDura)
        {
            if (itemSlotDura == null) return;
            _durability_UI.transform.gameObject.SetActive(true);
            _durability_UI.maxValue = (itemSlotDura.Item as AgriculturalObject).Durability;
            _durability_UI.value = itemSlotDura.Durability;
        }

        private void SetUpUiStack(ItemSlotStack itemSlotStack)
        {
            if ( itemSlotStack == null) return;
            _quantity.enabled = true;   
            _quantity.SetText(itemSlotStack.NumberItem.ToString());
        }
        
        
        private void OnStateActionChange(ItemSlot arg)
        {
            UpdateView(arg);
        }
    }
}

