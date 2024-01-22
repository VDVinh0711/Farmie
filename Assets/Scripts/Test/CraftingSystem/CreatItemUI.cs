using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatItemUI : MonoBehaviour
{

    [SerializeField] private List<CreatUiitemSlot> _uiSlots;
    [SerializeField] private CreatUiitemSlot _UIProduct;
    [SerializeField] private Crafting _crafting;

    private void Start()
    {
        Render();
        print("Render");
    }

    private void OnEnable()
    {
        _crafting.StateChangrCraft += Render;
    }
    
    private void Render()
    {
        for (int i = 0; i < _crafting.Ingredient.Length; i++)
        {
            _uiSlots[i].UpdateUI(_crafting.Ingredient[i]);
        }
        _UIProduct.UpdateUI(_crafting.Product);

    }

    private void OnDisable()
    {
        _crafting.StateChangrCraft -= Render;
    }
}
