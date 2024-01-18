
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
            
           //slot.StatechangeUI -= OnStateChange;
            var hasitem = slot.HasItem();
            var isstack = slot.IsstackAble;
            var isdurability = slot is ItemSlotDura && hasitem;
            var isactive = slot.IsActive;
            _durability_UI.transform.gameObject.SetActive(isdurability);
            _icon.enabled = hasitem;
            _quantity.enabled = isstack;
            _active.enabled = isactive;
           // slot.StatechangeUI += OnStateChange;
            if (!hasitem) return;
            _icon.sprite = slot.Item.UIinInven;
            settext(slot);
            setduraUI(slot);
            
        }
       /* private void OnStateChange(ItemSlot arg)
        {
            UpdateView(arg);
        }*/

        private void setduraUI(ItemSlot item)
        {
            var itemdura = item as ItemSlotDura;
            var itemobj = item.Item as AgriculturalObject;
            if (itemdura == null && itemobj == null) return;
            _durability_UI.maxValue = itemobj.Durability;
            _durability_UI.value = itemdura.Durability;
        }

        private void settext(ItemSlot item)
        {
            var itemstack = item as ItemSlotStack;
            if(itemstack == null) return;
            _quantity.SetText(itemstack.NumberItem.ToString());
        }

    }
}

