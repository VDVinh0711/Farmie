
using InventorySystem;
using UnityEngine;
using UnityEngine.UI;

public class UiInfor : MonoBehaviour
{
    
    [SerializeField] private Button _btnSellAnimal;
    [SerializeField] private Button _btnCureAnimal;
    [SerializeField] private Button _btnHarvest;
    [SerializeField] private AnimalInterac _animalInterac;
    private void Start()
    {
        _animalInterac = transform.GetComponentInParent<AnimalInterac>();
        _btnSellAnimal.onClick.AddListener(ButtonSellAnimal);
        _btnCureAnimal.onClick.AddListener(ButtonCareAnimal);
        _btnHarvest.onClick.AddListener(ButtonHarvest);
        HideButtonHarvest();
    }
    private void ButtonSellAnimal()
    {
     _animalInterac.SellAnimal();
    }
    private void ButtonCareAnimal()
    {
        _animalInterac.CureAnimal();
    }
    private void ButtonHarvest()
    {
        _animalInterac.HarvestProductAnimal();
    }
    public void ShowButtonHarvest()
    {
        _btnHarvest.gameObject.SetActive(true);
    }
    public void HideButtonHarvest()
    {
        _btnHarvest.gameObject.SetActive(false);
    }
    
}
