using System;
using System.Collections;
using InventorySystem;
using UnityEngine;


public class Crafting : Singleton<Crafting>
{
    [SerializeField] private bool _isCrafting;
    [SerializeField] private ItemSlot _product;
    [SerializeField] private int _quantity;
    [SerializeField] private ItemSlot[] _ingredient;
    public ItemSlot[] Ingredient => _ingredient;
    public ItemSlot Product => _product;
    public event Action StateChangrCraft; 
    
    private void OnEnable()
    {
        _ingredient = new ItemSlot[2];
        for (int i = 0; i < _ingredient.Length; i++)
        {
            _ingredient[i] = new ItemSlot();
        }
    }

    public void Craft()
    {
        var item1 = _ingredient[0] as ItemSlotStack;
        var item2 = _ingredient[1] as ItemSlotStack;
        _quantity = (item1 == null || item2 == null) ? 1 :
            item1.NumberItem > item2.NumberItem ? item2.NumberItem : item1.NumberItem;
        var itemcraft = CeatItemCraftSO.GetItemScraft(item1.Item, item2.Item);
        StartCoroutine(WaitngCraft(item1,item2));
    }
    IEnumerator WaitngCraft(ItemSlotStack item1, ItemSlotStack item2)
    {
        _isCrafting = true;
        ingridentAftetCraft(_quantity);
        var itemcraft = CeatItemCraftSO.GetItemScraft(item1.Item, item2.Item);
        if (itemcraft == null) yield break;
        var timeup = itemcraft.TimeCreat;
        yield return  new WaitForSeconds(timeup);
        _isCrafting = false;
        _product = itemcraft.itemCraf is IStackAble
            ? new ItemSlotStack(itemcraft.itemCraf, _quantity)
            : new ItemSlotDura(itemcraft.itemCraf);
        BagsManager.Instance.AddItem2(_product);
        OnStateChange();
    }

    public void AddItemSlot(ItemSlot itemSlot)
    {
            
        for (int i = 0; i < _ingredient.Length; i++)
        {
            if(_ingredient[i].HasItem()) continue;
            _ingredient[i] = itemSlot;
            break;
        }
        OnStateChange();
    }

    private void ingridentAftetCraft(int _quantity )
    {
        for (int i = 0; i < _ingredient.Length; i++)
        {
            switch (_ingredient[i])
            {
                case ItemSlotStack:
                    (_ingredient[i] as ItemSlotStack).NumberItem -= _quantity; 
                    break;
                case ItemSlotDura:
                    _ingredient[i].SetEmty();
                    break;
            }
        }

        OnStateChange();
    }

    private void OnStateChange()
    {
        StateChangrCraft?.Invoke();
    }

   

   
}
