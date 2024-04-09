
using InventorySystem;
using UnityEngine.EventSystems;


public class UI_SlotInCraf :UI_Slots,IPointerClickHandler
{
   public  void OnPointerClick(PointerEventData eventData)
   {
      switch (Slot)
      {
         case ItemSlotStack  Slot:
            ComfirmQuantity.Instance.Show(GetItemStack,"So Luong");
            break;
         case ItemSlotDura  :
            GetItemDura();
            break;
      }
   }
   private void GetItemStack(int number)
   {       
     
      if( !CrafSystem.Instance.CanAddItemAsIngredient(Slot)) return;
      CrafSystem.Instance.AddItemAsIngredient((Slot as ItemSlotStack).GetItemSlotStack(number));
   }
   private void GetItemDura()
   {
      if( !CrafSystem.Instance.CanAddItemAsIngredient(Slot)) return;
      CrafSystem.Instance.AddItemAsIngredient((Slot as ItemSlotDura).GetItemSlotDure());
   }
   
   
}
