
using InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DesCripteRecipe : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameItem;
    [SerializeField] private Image _ingridient1;
    [SerializeField] private Image _ingridient2;
    [SerializeField] private Image _product;
    [SerializeField] private Transform _panel;
    public void ShowDesription(CeatItemCraftSO itemCraftSo)
    {
        var bag = FindObjectOfType<Bag>();
        _panel.gameObject.SetActive(itemCraftSo != null);
        if (itemCraftSo == null) return;
        _nameItem.SetText(itemCraftSo.ID);
        _product.sprite = itemCraftSo.itemCraf.UIinInven;
        _ingridient1.sprite = itemCraftSo.item11.UIinInven;
        _ingridient1.color = bag.GetItemByItemOBJ(itemCraftSo.item11) == null ? Color.red : Color.white;
        _ingridient2.sprite = itemCraftSo.item22.UIinInven;
        _ingridient2.color = bag.GetItemByItemOBJ(itemCraftSo.item22) == null ? Color.red : Color.white;
    }
}
