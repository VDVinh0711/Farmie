
using InventorySystem;

public static class MappingItem 
{


    public static ItemSlot ItemSOtoObj(Item_SO itemSo)
    {
        switch (itemSo)
        
        {
            case  IStackAble itemStack :
                return new ItemSlotStack(itemSo, itemStack.CurrentStack);
                break;
            case AgriculturalSo itemAgri :
                return new ItemSlotDura(itemSo, itemAgri.CurrentDura);
                break;
            case ClothesItem_SO itemclothes:
                return new ItemSlotClothes(itemclothes);
            break;
            default:
                return new ItemSlot(itemSo);
        }
    }
}
