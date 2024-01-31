
using UI.UI_Shop;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;


public class UIShop : MonoBehaviour,IPointerExitHandler,IPointerEnterHandler
{
    
    [SerializeField] private UI_ShopPanel _shopPanel;
    [SerializeField] private UI_InvenyotyInShop _invenpanel;
    [SerializeField] private UI_ActiveComfirmBuy activeComfirmBuy;
    [SerializeField] private UI_ButtonChoseOption _choseOption;
    [SerializeField] private RectTransform panle;
    [FormerlySerializedAs("_sellComfirm")] [SerializeField] private UI_ActiveComfirmSell quantityComfirm;
    [SerializeField] private bool checkoutSide = false;
    [SerializeField] public Transform ShopPanel;
    [SerializeField]    public Transform InvenPanel;
    public UI_ShopPanel Shop => _shopPanel;
    public UI_InvenyotyInShop InventoryShop => _invenpanel;
    public UI_ActiveComfirmBuy ActiveComfirmBuy => activeComfirmBuy;
    public UI_ActiveComfirmSell ComfirmQuantity => quantityComfirm;

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
