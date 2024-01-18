using System;

namespace InventorySystem
{
    [Serializable]
   public struct Itemdata
   {
       public string ID;
       public int Quantity;
       public int Durability;
       public bool IsStackABle;
       
       public Itemdata(string id, int quantity,int durability,bool isStackABle)
       {
           ID = id;
           Quantity = quantity;
           IsStackABle = isStackABle;
           Durability = durability;
       }
   }
}

