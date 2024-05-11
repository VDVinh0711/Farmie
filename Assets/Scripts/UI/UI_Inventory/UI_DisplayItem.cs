
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
            _durability_UI.interactable = false;
        }
        public void UpdateView(ItemSlot  slot)
        {
            slot.ActionChangeItem -= OnStateActionChange;
            slot.ActionChangeItem += OnStateActionChange;
            var hasitem = slot.HasItem();
            var isactive = slot.IsActive && hasitem;
            _icon.enabled = hasitem;
            _quantity.enabled = false;
            _active.enabled = isactive;
            _durability_UI.transform.gameObject.SetActive(false);
            if (!slot.HasItem()) return;
            _icon.sprite = slot.Item.ItemInfor.UIinInven;
            switch (slot.Item)
            {
                case ItemStack:
                    SetUpUiStack(slot.Item as ItemStack);
                    break;
                case ItemDura:
                    SetUiDuraable(slot.Item as ItemDura);
                    break;
            }
            
        }
        private void SetUiDuraable(ItemDura itemDura)
        {
            if (itemDura == null) return;
            _durability_UI.transform.gameObject.SetActive(true);
            _durability_UI.maxValue = (itemDura.ItemInfor as AgriculturalSo).MaxDurability;
            _durability_UI.value = itemDura.CurDurability;
        }
        private void SetUpUiStack(ItemStack itemStack)
        {
            if ( itemStack == null) return;
            _quantity.enabled = true;   
            _quantity.SetText(itemStack.NumberItem.ToString());
        }
        private void OnStateActionChange(ItemSlot arg)
        {
            UpdateView(arg);
        }
        
    }
}

