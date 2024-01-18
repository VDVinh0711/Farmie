
using UI.UI_Shop;
using UnityEngine;
using UnityEngine.EventSystems;


public class UIShop : MonoBehaviour,IPointerExitHandler,IPointerEnterHandler
{
    
    [SerializeField] private UI_ShopPanel _shopPanel;
    [SerializeField] private UI_InvenyotyInShop _invenpanel;
    [SerializeField] private UI_ActiveComfirmBuy activeComfirmBuy;
    [SerializeField] private UI_ButtonChoseOption _choseOption;
    [SerializeField] private RectTransform panle;
    [SerializeField] private UI_ActiveComfirmSell _sellComfirm;
    [SerializeField] private bool checkoutSide = false;
    [SerializeField] public Transform ShopPanel;
    [SerializeField]    public Transform InvenPanel;
    public UI_ShopPanel Shop => _shopPanel;
    public UI_InvenyotyInShop InventoryShop => _invenpanel;
    public UI_ActiveComfirmBuy ActiveComfirmBuy => activeComfirmBuy;
    public UI_ActiveComfirmSell ActiveComfirmSell => _sellComfirm;

    public void OpenUiShop()
    {
        UIManager.OpenUI(panle); 
    }

    private void LateUpdate()
    {
        if(!panle.gameObject.activeSelf) return;
        if (Input.GetMouseButtonDown(0))
        {
            if (checkoutSide)
            {
                HideShop();
            }
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
       checkoutSide = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        checkoutSide = false;
    }

    private void HideShop()
    {
        UIManager.HideUI(panle);
        checkoutSide = false;
    }
}
