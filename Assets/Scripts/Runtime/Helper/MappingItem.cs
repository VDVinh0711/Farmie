
using InventorySystem;

public static class MappingItem 
{


    public static ItemSlot ItemSOtoObj(ItemSlot itemSlot)
    {
        switch (itemSlot)
        {
            case  ItemSlotStack itemStack :
                return new ItemSlotStack(itemStack);
                break;
            case ItemSlotDura itemAgri :
                return new ItemSlotDura(itemAgri);
                break;
            case  ItemSlotClothes itemclothes:
                return new ItemSlotClothes(itemclothes);
            break;
            default:
                return new ItemSlot(itemSlot);
        }
    }
    
    
}
