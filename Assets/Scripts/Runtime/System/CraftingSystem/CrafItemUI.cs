

using InventorySystem;
using UnityEngine.EventSystems;

public class CrafItemUI :UI_Slots,IPointerClickHandler
{
    public  void OnPointerClick(PointerEventData eventData)
    {
            Bag.Instance.AddItem(_slot);
            _slot.SetEmty();
    }
}
