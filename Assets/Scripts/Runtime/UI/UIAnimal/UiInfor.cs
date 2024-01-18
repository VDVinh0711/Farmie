
using InventorySystem;
using UnityEngine;
using UnityEngine.UI;

public class UiInfor : MonoBehaviour,IActionAccept
{
    [SerializeField] private Animal _animal;
    [SerializeField] private Button _btnSellAnimal;
    [SerializeField] private Button _btnCureAnimal;
    [SerializeField] private Button _btnHarvest;
    [SerializeField] private CureAnimal _cureAnimal;
    private void Start()
    {
        _btnSellAnimal.onClick.AddListener(ButtonSellAnimal);
        _btnCureAnimal.onClick.AddListener(ButtonCareAnimal);
        _btnHarvest.onClick.AddListener(ButtonHarvest);
        HideButtonHarvest();

    }
    
    private void ButtonSellAnimal()
    {
        ComfirmManager.Intance.Show("Bạn có muốn bán với giá " + _animal.SellAnimal.getpriceSell() ,this);
    }

    private void ButtonCareAnimal()
    {
        _cureAnimal.Cure();
    }

    private void ButtonHarvest()
    {
        
        if (BagsManager.Instance.AddItem(_animal.AnimalObject.Itemharvest, 1))
        {
            _animal.PhysiologicalState.IsHarvest = false;
            _animal.GrowAnimal.SetTimeDefautHarvest();
        }
    }

    public void ShowButtonHarvest()
    {
        _btnHarvest.gameObject.SetActive(true);
    }

    public void HideButtonHarvest()
    {
        _btnHarvest.gameObject.SetActive(false);
    }

    public void ActionAccept()
    {
        _animal.SellAnimal.sellAnimal();
      
    }
}
