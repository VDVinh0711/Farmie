
using UnityEngine.EventSystems;


namespace InventorySystem
{
    
    public class UI_Inventoryslot : UI_Slots,IPointerClickHandler
    {
        
           public  void OnPointerClick(PointerEventData eventData)
           {
               if(!_slot.HasItem()) return;
               if (eventData.button == PointerEventData.InputButton.Left) {
                   _slot.IsActive = true;
                   var inventoryController = FindObjectOfType<InventoryController>();
                  if(inventoryController == null) return;
                    inventoryController.ActiveItemInVen(this);
               } 
               
           }

    }
}

