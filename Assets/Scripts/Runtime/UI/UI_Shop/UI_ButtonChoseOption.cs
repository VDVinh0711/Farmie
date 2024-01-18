
using UnityEngine;
using UnityEngine.UI;

public class UI_ButtonChoseOption : MonoBehaviour
{
    [SerializeField] private Button _changeInven;
    [SerializeField] private Button _changeShop;
    [SerializeField] private UIShop _uiSHop;

    private void Start()
    {
        _uiSHop = transform.parent.GetComponent<UIShop>();
        _changeInven.onClick.AddListener(Invenlick);
        _changeShop.onClick.AddListener(Shoplick);
    }
    private void  Invenlick()
    {
        if (_uiSHop == null) _uiSHop = GameObject.FindAnyObjectByType<UIShop>();
        SetActiveButton(_changeInven);
        _uiSHop.ShopPanel.gameObject.SetActive(false);
        _uiSHop.InvenPanel.gameObject.SetActive(true);
        
       _uiSHop.InventoryShop.RenderInvenInShop();
    }
    private void  Shoplick()
    {
        if (_uiSHop == null) _uiSHop = GameObject.FindAnyObjectByType<UIShop>();
        SetActiveButton(_changeShop);
        _uiSHop.InvenPanel.gameObject.SetActive(false);
        _uiSHop.ShopPanel.gameObject.SetActive(true);
    }
    private void SetDefautButton()
    {
        _changeInven.image.color = Color.HSVToRGB(132,132,132);
        _changeShop.image.color = Color.HSVToRGB(132,132,132);
    }

    private void SetActiveButton(Button button)
    {
        SetDefautButton();
        button.image.color = Color.white;
    }
}
