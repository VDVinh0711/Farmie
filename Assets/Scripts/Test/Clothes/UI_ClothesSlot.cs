
using InventorySystem;
using UnityEngine;
using UnityEngine.EventSystems;

    public class UI_ClothesSlot : UI_Slots,IPointerClickHandler
    {
        
        
        public virtual void OnPointerClick(PointerEventData eventData)
        {
            
            print("run ui clothes data");
            var itemClothesController = FindObjectOfType<ItemClothesController>();
            
            itemClothesController.AddItemInPlayer(_slot);
        }
    }



