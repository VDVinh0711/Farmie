

using InventorySystem;
using UnityEngine.EventSystems;

public class CrafItemUI :UI_Slots,IPointerClickHandler
{
    public  void OnPointerClick(PointerEventData eventData)
    {
        var bag = FindObjectOfType<Bag>();
        bag.AddItem(_slot.Item);
        _slot.SetEmty();
    }
}
