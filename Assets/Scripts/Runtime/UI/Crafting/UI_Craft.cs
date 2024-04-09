using System.Collections.Generic;
using System.Linq;
using InventorySystem;
using Player;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UI_Craft : MonoBehaviour
{
    [SerializeField] private Bag _bag;
    [SerializeField] private List<UI_Slots> _itemSlot  = new();
    [SerializeField] private List<UI_Slots> _ingredientUISlots = new ();
    [SerializeField] private UI_Slots _productUISlot;
    [SerializeField] private CrafSystem _crafSystemSystem;
    [SerializeField] private Transform _itemSlotPrefab;
    [SerializeField] private Transform _rootUIContainer;
    [SerializeField] private Transform _panel;
    private void InitializeUI()
    {
        CreateInventorySlots();
        UpdateUI();
    }
    private void CreateInventorySlots()
    {
        foreach (var slotIndex in Enumerable.Range(0, _bag.Slot.Length))
        {
            var slotUI = Instantiate(_itemSlotPrefab, _rootUIContainer).GetComponent<UI_SlotInCraf>();
            slotUI.AssighIndex(slotIndex);
            _itemSlot.Add(slotUI);
        }
        DisplayInventoryItems();
    }
    private void DisplayInventoryItems()
    {
        for (int i = 0; i < _bag.Slot.Length-1; i++)
        {
            _itemSlot[i].Display(_bag.Slot[i]);
        }
    }
    private void UpdateUI()
    {
        DisplayInventoryItems();
        DisplayIngredients();
        DisplayProduct();
    }
    private void DisplayIngredients()
    {
        foreach (var ingredientIndex in Enumerable.Range(0, _crafSystemSystem.CraftingIngredients.Length))
        {
            _ingredientUISlots[ingredientIndex].Display(_crafSystemSystem.CraftingIngredients[ingredientIndex]);
        }
    }
    private void DisplayProduct()
    {
        _productUISlot.Display(_crafSystemSystem.CraftedProduct);
    }
    private void OnDisable()
    {
        _crafSystemSystem.CraftingStateChange -= UpdateUI;
        _bag.StateChangeBags -= UpdateUI;
    }
    public void ToggleCraftingUI()
    {
        if (_panel.gameObject.activeSelf)
        {
            HideUI();
        }
        else
        {
            OpenUI();
        }
    }
    public void OpenUI()
    {
        SetupBegin();
        UIManager.OpenUI(_panel);
    }
    private void SetupBegin()
    {
         _bag =  _crafSystemSystem.PlayerManager.Bag;
        InitializeUI();
        UpdateUI();
        _crafSystemSystem.CraftingStateChange += UpdateUI;
        _bag.StateChangeBags += UpdateUI;
    }
    public void HideUI()
    {
        UIManager.HideUI(_panel);
    }
}
