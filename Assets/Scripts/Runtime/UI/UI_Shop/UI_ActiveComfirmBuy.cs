
using Player;
using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class UI_ActiveComfirmBuy : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _txtNameItem;
    [SerializeField] private Image _imgItem;
    [SerializeField] private TextMeshProUGUI _txtQuantity;
    [SerializeField] private TextMeshProUGUI _txtCost;
    [SerializeField] private Button _btnAddItem;
    [SerializeField] private Button _btnPreItem;
    [SerializeField] private Button _btnComfirm;
    [SerializeField] private Button _btnCancle;
    private Shop _shop;
    private ItemShopObject _itemdata;
    private int _quantityBuy = 1;
    private void Start()
    {
        _btnAddItem.onClick.AddListener(AddItem);
        _btnPreItem.onClick.AddListener(PreItem);
        _btnComfirm.onClick.AddListener(ConfirmButton);
        _btnCancle.onClick.AddListener(CancleButton);
    }
    public void RenderComfirmPanel(ItemShopObject item)
    {
        if(item == null) return;
        _itemdata = item;
        _txtNameItem.SetText(_itemdata.name);
        _imgItem.sprite = _itemdata.Thumail;
        _txtQuantity.SetText(_quantityBuy.ToString());
        _txtCost.SetText((_quantityBuy * _itemdata.Price).ToString() + "$");
    }
    private void AddItem()
    {
        _quantityBuy++;
        if((_quantityBuy * _itemdata.Price ) > PlayerManager.Instance.PlayerStats.Money)
            _quantityBuy = (int)(PlayerManager.Instance.PlayerStats.Money / _itemdata.Price);
        RenderComfirmPanel(_itemdata);
    }
    private void PreItem()
    {
        _quantityBuy--;
        if (_quantityBuy <= 1)
            _quantityBuy = 1;
        RenderComfirmPanel(_itemdata);
    }
    private void ConfirmButton()
    {
        if (_shop == null) _shop = GameObject.FindAnyObjectByType<Shop>();
        _shop.Purchare(_itemdata,_quantityBuy);
        Reset();
    }
    private void CancleButton()
    {
        Reset();
    }
    private void Reset()
    {
        transform.gameObject.SetActive(false);
        _quantityBuy = 1;
    }
    public void ShowComfrimPanel()
    {
        var show = gameObject.activeSelf ? false : true;
        transform.gameObject.SetActive(show);
    }
}
