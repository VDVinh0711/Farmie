using System.Collections.Generic;
using System.Linq;
using InventorySystem;
using UnityEngine;
using UnityEngine.UI;

public class UI_Craft : MonoBehaviour
{
    [SerializeField] private List<UI_Slots> _inventorySlots;
    [SerializeField] private List<UI_Slots> _ingredientUISlots;
    [SerializeField]  private UI_Slots _productUISlot;
    [SerializeField] private CrafSystem _crafSystemSystem;
    [SerializeField] private Transform _itemSlotPrefab;
    [SerializeField] private Transform _rootUIContainer;
    [SerializeField] private Transform _panel;
    private void Start()
    {
        InitializeUI();
        _crafSystemSystem.CraftingStateChange += UpdateUI;
        Bag.Instance.StateChangeBags += UpdateUI;
    }
    private void InitializeUI()
    {
        CreateInventorySlots();
        UpdateUI();
    }
    private void CreateInventorySlots()
    {
        foreach (var slotIndex in Enumerable.Range(0, Bag.Instance.Slot.Length))
        {
            var slotUI = Instantiate(_itemSlotPrefab, _rootUIContainer).GetComponent<UI_SlotInCraf>();
            slotUI.AssighIndex(slotIndex);
            _inventorySlots.Add(slotUI);
        }
        DisplayInventoryItems();
    }
    private void DisplayInventoryItems()
    {
        for (int i = 0; i < Bag.Instance.Slot.Length; i++)
        {
            _inventorySlots[i].Display(Bag.Instance.Slot[i]);
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
        Bag.Instance.StateChangeBags -= UpdateUI;
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
        UpdateUI();
        UIManager.OpenUI(_panel);
    }
    public void HideUI()
    {
        UIManager.HideUI(_panel);
    }
}
