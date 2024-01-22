using System;

namespace InventorySystem
{
    [Serializable]
   public struct Itemdata
   {
       public string ID;
       public int Quantity;
       public int Durability;
       public Itemdata(string id, int quantity,int durability)
       {
           ID = id;
           Quantity = quantity;
           Durability = durability;
       }
   }
}

