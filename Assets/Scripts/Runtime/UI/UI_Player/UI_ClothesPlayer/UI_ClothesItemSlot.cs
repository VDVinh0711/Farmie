using InventorySystem;
using UnityEngine.EventSystems;

public class UI_ClothesItemSlot : UI_Slots,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if(_slot.Item == null) return;
        var modelController = FindObjectOfType<ModelPlayerManager>();
        if (modelController == null) return;
        modelController.BackClothesInBag(_slot as ItemSlotClothes);
    }
}
