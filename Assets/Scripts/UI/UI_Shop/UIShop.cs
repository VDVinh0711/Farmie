using System.Collections.Generic;
using UI.UI_Shop;
using UnityEngine;
using UnityEngine.UI;

public class UIShop : MonoBehaviour
{
    
    [SerializeField] private UI_ShopPanel _shopPanel;
    [SerializeField] private UI_InvenyotyInShop _invenpanel;
    [SerializeField] private UI_ActiveComfirmBuy activeComfirmBuy;
    [SerializeField] private UI_ButtonChoseOption _choseOption;
    [SerializeField] private RectTransform panle;
    [SerializeField] public Transform ShopPanel;
    [SerializeField] public Transform InvenPanel;
    [SerializeField] private Button _btnClose;
    public UI_ShopPanel Shop => _shopPanel;
    public UI_InvenyotyInShop InventoryShop => _invenpanel;
    public UI_ActiveComfirmBuy ActiveComfirmBuy => activeComfirmBuy;
   
    private void Awake()
    {
        _btnClose.onClick.AddListener(HideShop);
    }

    public void OpenUiShop(List<ItemShopObject> itemShopObjects)
    {
        UIManager.OpenUI(panle); 
        _shopPanel.InstantiateShop(itemShopObjects);
    }
    private void HideShop()
    {
        UIManager.HideUI(panle);
    }
}
