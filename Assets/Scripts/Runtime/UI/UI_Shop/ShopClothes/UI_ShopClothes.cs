
using System;
using UnityEngine;

public class UI_ShopClothes : MonoBehaviour
{
    [SerializeField] private ShopClothes _shopClothes;
    [SerializeField] private Transform _itemShopClothesPre;
    [SerializeField] private Transform _pool;
    [SerializeField] private UIDescripeIteminShop _uiDescripeIteminShop;
    [SerializeField] private Transform _panel;
    public void DisPlayShop()
    {
        Refesh();
        for (int i = 0; i < _shopClothes.LengtClothes; i++)
        {
            var itemShopItem = Instantiate(_itemShopClothesPre, _pool).GetComponent<UI_ItemClothesShop>();
            itemShopItem.DisPlay(_shopClothes.ListClothes[i],i);
        }
    }
    private void Refesh()
    {
        foreach (var itemshop in  _pool.GetComponentsInChildren<UI_ItemClothesShop>())
        {
            Destroy(itemshop.gameObject);
        }
    }
    public void ShowDesScripte()
    {
        _uiDescripeIteminShop.SetTextShow(_shopClothes.ItemCrentActive.itemShopObject);
        _uiDescripeIteminShop.SetModelPeView(_shopClothes.ItemCrentActive.itemShopObject);
    }
    private void Hide()
    {
        _panel.gameObject.SetActive(false);
    }
    private void Show()
    {
        _panel.gameObject.SetActive(true);
        DisPlayShop();
        _uiDescripeIteminShop.SetModelPreViewBegin();
        _uiDescripeIteminShop.SetTextShow(_shopClothes.ItemCrentActive.itemShopObject);
    }
    public void Toggle()
    {
        if (_panel.gameObject.activeSelf)
        {
            Hide();
            return;
        }
        Show();
    }
}
