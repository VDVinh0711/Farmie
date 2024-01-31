
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_RecipeSlot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    [SerializeField] private CeatItemCraftSO _craftItem;
    [SerializeField] private Image _icon;
    [SerializeField] private DesCripteRecipe _desCripteRecipe;

    private void Start()
    {
        _desCripteRecipe = FindObjectOfType<DesCripteRecipe>();
    }

    public void Display(CeatItemCraftSO ceatItemCraftSo)
    {
        if(ceatItemCraftSo == null) return;
        _craftItem = ceatItemCraftSo;
        _icon.sprite = _craftItem.itemCraf.UIinInven;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _desCripteRecipe.ShowDesription(_craftItem);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      _desCripteRecipe.ShowDesription(null);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        print("CLick");
        // lấy ingridient trỏng bag đưa  lên slot để craft
        /*var listingridient = new List<ItemObject>();
        listingridient.Add(_craftItem.item11);
        listingridient.Add(_craftItem.item22);
        foreach (var ingridient in listingridient)
        {
            var itemslot = Bag.Instance.GetItemByItemOBJ(ingridient);
            if(itemslot == null) return;
            var itemcraft = itemslot is ItemSlotDura
                ? (itemslot as ItemSlotDura).GetItemSlotDure()
                : (itemslot as ItemSlotStack).GetItemSlotStack(1);
            CrafSystem.Instance.AddIngredient(itemcraft);
        }*/
    }
}
