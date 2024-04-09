using System;
using InventorySystem;
using Photon.Pun.Demo.PunBasics;
using UnityEngine;
using PlayerManager = Player.PlayerManager;

//Dùng Singletone đề Lười , Dùng để get Crafting khi cần thiết
public class CrafSystem : Singleton<CrafSystem>,IInterac
{
    [SerializeField] private UI_Craft _uiCraft;
    [SerializeField] private PlayerManager _playerManager;
    private ItemSlot _craftedProduct;
    private int _craftQuantity;
    private ItemSlot[] _craftingIngredients;
    public ItemSlot[] CraftingIngredients => _craftingIngredients;
    public ItemSlot CraftedProduct => _craftedProduct;
    public event Action CraftingStateChange;
    public PlayerManager PlayerManager => _playerManager;
    private void OnEnable()
    {
        InitializeIngredientSlots();
    }
    private void InitializeIngredientSlots()
    {
        _craftingIngredients = new ItemSlot[2];
        for (int i = 0; i < _craftingIngredients.Length; i++)
        {
            _craftingIngredients[i] = new ItemSlot();
        }
        _craftedProduct = new ItemSlot();
    }
    public void Craft()
    {
        if(!_craftingIngredients[0].HasItem() || !_craftingIngredients[1].HasItem()) return;
        var ingredient1 = _craftingIngredients[0] as ItemSlotStack;
        var ingredient2 = _craftingIngredients[1] as ItemSlotStack;
        _craftQuantity = DetermineCraftQuantity(ingredient1, ingredient2);
        var craftResult = CeatItemCraftSO.GetItemScraft(ingredient1.Item, ingredient2.Item);//Lấy Ra item được craft từ các SO ở Resouce
        _craftedProduct = CreateProductSlot(craftResult.itemCraf, _craftQuantity);
        ApplyIngredientChangesAfterCrafting(_craftQuantity);
        NotifyCraftingStateChange();
    }
    private int DetermineCraftQuantity(ItemSlotStack ingredient1, ItemSlotStack ingredient2)
    {
        
        //lấy ra số Item nhỏ nhất trong 2 Igridient để craft
        if (ingredient1 == null || ingredient2 == null)
        {
            return -1;
        }
        return Mathf.Min(ingredient1.NumberItem, ingredient2.NumberItem);
    }
    private ItemSlot CreateProductSlot(Item_SO productItem, int quantity)
    {
        return productItem is IStackAble ? new ItemSlotStack(productItem, quantity) : new ItemSlotDura(productItem);
    }
    public bool CanAddItemAsIngredient(ItemSlot itemSlot)
    {
        foreach (var ingredient in CraftingIngredients)
        {
            if (!ingredient.HasItem())
            {
                return true;  // Empty slot found
            }

            if (ingredient is ItemSlotStack ingredientStack && ingredientStack.Item == itemSlot.Item)
            {
                return true;  // Same item type already exists in a stack
            }
        }

        return false;  // No empty slots or matching stacks found
    }
    public void AddItemAsIngredient(ItemSlot itemSlot)
    {
        if (itemSlot == null)
        {
            return;
        }

        if (!CanAddItemAsIngredient(itemSlot))
        {
            return;
        }

        for (int i = 0; i < CraftingIngredients.Length; i++)
        {
            if (CraftingIngredients[i].HasItem())
            {
                if (CraftingIngredients[i] is ItemSlotStack ingredientStack && itemSlot is ItemSlotStack itemStack && itemSlot.Item == CraftingIngredients[i].Item)
                {
                    ingredientStack.NumberItem += itemStack.NumberItem;  // Combine stacks
                    NotifyCraftingStateChange();
                    break;
                }
            }
            else
            {
                CraftingIngredients[i] = itemSlot;  // Place item in empty slot
                NotifyCraftingStateChange();
                break;
            }
        }
    
      
    }
    private void ApplyIngredientChangesAfterCrafting(int quantity)
    {
        
        //Các Ingridiet sau khi craft
        foreach (var ingredient in _craftingIngredients)
        {
            switch (ingredient)
            {
                case ItemSlotStack stackableIngredient:
                    stackableIngredient.PreviousItem(quantity);
                    break;
                case ItemSlotDura durableIngredient:
                    durableIngredient.SetEmty();
                    break;
            }
        }
        NotifyCraftingStateChange();
    }
    private void NotifyCraftingStateChange()
    {
        CraftingStateChange?.Invoke();
    }

    public void InterRac(PlayerManager playerManager)
    {
        _playerManager = playerManager;
        _uiCraft.ToggleCraftingUI();
    }
}
