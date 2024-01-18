
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ItemInShopSlot :MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI cost;
    [SerializeField] private Image thumnail;
    [SerializeField] private ItemShopObject _itemShopObject;
    [SerializeField] private UIShop _uishop;
    public void DisPlay(ItemShopObject itemdata)
    {
        if (itemdata == null) return;
        _itemShopObject = itemdata;
        _name.text = itemdata.name;
        cost.text = itemdata.Price + "$";
        thumnail.sprite = itemdata.Thumail;
    }
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if(_uishop == null) _uishop = GameObject.FindAnyObjectByType<UIShop>();
        _uishop.ActiveComfirmBuy.ShowComfrimPanel();
        _uishop.ActiveComfirmBuy.RenderComfirmPanel(_itemShopObject);
    }

    
}
