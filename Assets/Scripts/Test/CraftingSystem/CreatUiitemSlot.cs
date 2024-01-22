using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using TMPro;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreatUiitemSlot : MonoBehaviour,IPointerClickHandler
{
   [SerializeField] private Image _iconItem;
   [SerializeField] private TextMeshProUGUI _quantity;
   [SerializeField] private Slider _duraable;
   [SerializeField] private ItemSlot _itemSlot;

   public void UpdateUI(ItemSlot itemSlot)
   {
      _itemSlot = itemSlot;
      var hasItem = itemSlot.HasItem();
      _iconItem.enabled = hasItem;
      _quantity.enabled = false;
      _duraable.gameObject.SetActive(false);
      if(!hasItem) return;
      _iconItem.sprite = itemSlot.Item.UIinInven;
      switch (itemSlot)
      {
         case ItemSlotStack :
            SetUpUiStack(itemSlot as ItemSlotStack);
            break;
         case ItemSlotDura:
            SetUiDuraable(itemSlot as ItemSlotDura);
            break;
      }
   }

   private void SetUiDuraable(ItemSlotDura itemSlotDura)
   {
      _duraable.gameObject.SetActive(true);
      _duraable.maxValue = (itemSlotDura.Item as AgriculturalObject).Durability;
      _duraable.value = itemSlotDura.Durability;
   }

   private void SetUpUiStack(ItemSlotStack itemSlotStack)
   {
      _quantity.enabled = true;   
      _quantity.SetText(itemSlotStack.NumberItem.ToString());
   }
   public void OnPointerClick(PointerEventData eventData)
   {
      BagsManager.Instance.AddItem2(_itemSlot);
      _itemSlot.SetEmty();
      UpdateUI(_itemSlot);
   }
}
