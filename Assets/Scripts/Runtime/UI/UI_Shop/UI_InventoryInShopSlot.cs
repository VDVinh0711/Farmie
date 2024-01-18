
using InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_InventoryInShopSlot : MonoBehaviour,IPointerClickHandler
{
    [SerializeField]
    private Image _uiShowimage;
    [SerializeField]
    private TextMeshProUGUI _uiShowQUantity;
    [SerializeField]
    private ItemSlot _itemSlot;

    [SerializeField] private UIShop _uiShop;

    public ItemSlot Itemslot
    {
        get => _itemSlot;
        set
        {
            _itemSlot = value;
        }
    }

    public void RenderItem(ItemSlot itemSlot)
    {
        _itemSlot = itemSlot;
        var hasItem = itemSlot.Item != null;
        _uiShowimage.transform.parent.gameObject.SetActive(hasItem);
        UpdateView(itemSlot);
    }

    private void UpdateView(ItemSlot item)
    {
        _uiShowimage.sprite = item.Item.UIinInven;
        if (item is ItemSlotStack)
        {
       _uiShowQUantity.SetText((item as ItemSlotStack).NumberItem.ToString());
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_uiShop == null) _uiShop = GameObject.FindAnyObjectByType<UIShop>();
        print("Run show");
        _uiShop.ActiveComfirmSell.Show(_itemSlot);
    }
}
