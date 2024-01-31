using InventorySystem;
using UnityEngine;
public class AnimalInterac : MonoBehaviour,IInterac,IActionAccept
{
    [SerializeField] private Animal _animal;
    [SerializeField] private AnimalBehavor _animalBehavor;
    [SerializeField]private UiAnimal _uianimal;
    private void Start()
    {
        _animal = GetComponent<Animal>();
        _uianimal = transform.GetComponent<UiAnimal>();
        _animalBehavor = GetComponent<AnimalBehavor>();
    }
    public void InterRac()
    {
        _uianimal.ShowUIinfor();
    }

    public void CureAnimal()
    {
        if (!_animal.IsSick)
        {
            EventManger<string>.RaiseEvent("ShowNotifycation","Vật nuôi của bạn không bị bệnh");
            return;
        }
        EquidmentObject eqidItem = Bag.Instance.HandItem.Item as EquidmentObject;
        if (eqidItem == null)
        {
            EventManger<string>.RaiseEvent("ShowNotifycation","Bạn phải có thuốc để chữa bệnh");
            return;
        }
        eqidItem.Used(_animal);
        Bag.Instance.HandItem.UseItem();
    }

    public void HarvestProductAnimal()
    {
        if (Bag.Instance.AddItem(_animal.AnimalObject.Itemharvest, 1))
        {
            _animal.PhysiologicalState.IsHarvest = false;
            _animal.GrowAnimal.SetTimeDefautHarvest();
        }
    }
    public void SellAnimal()
    {
        ComfirmManager.Intance.Show("Bạn có muốn bán với giá " + _animal.SellAnimal.getpriceSell() ,this);
    }
    public void ActionAccept()
    {
        _animal.SellAnimal.sellAnimal();
    }
}

