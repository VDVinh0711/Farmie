using System;

public enum InventoryOperation
{
    None,
    Add,
    Remove
}
public class InventoryExCeption : Exception
{

    public InventoryOperation Operation { get;  }
    //Call when Inventory Full or Invalid Item 
    public InventoryExCeption( InventoryOperation inventoryOperation,string msg):base($"{inventoryOperation} Erro {msg}") 
    {
        Operation = inventoryOperation;   
    }
}
