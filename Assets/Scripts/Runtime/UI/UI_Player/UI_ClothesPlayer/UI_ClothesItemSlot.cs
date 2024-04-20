using InventorySystem;
using UnityEngine.EventSystems;

public class UI_ClothesItemSlot : UI_Slots,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        
        if(!_slot.HasItem()) return;
        var modelController = FindObjectOfType<ModelPlayerController>();
        if (modelController == null) return;
        modelController.BackClothesInBag(_slot);
    }
}
