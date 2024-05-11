using InventorySystem;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

public class AnimalInterac : MonoBehaviour,IInterac,IActionAccept
{
    [SerializeField] private Animal _animal;
    [FormerlySerializedAs("_animalBehavor")] [SerializeField] private AnimalBehavior animalBehavior;
    [SerializeField]private UiAnimal _uianimal;
    [SerializeField] private Bag _bag;
    private void Start()
    {
        _animal = GetComponent<Animal>();
        _uianimal = transform.GetComponent<UiAnimal>();
        animalBehavior = GetComponent<AnimalBehavior>();
        _bag = FindObjectOfType<Bag>();
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
        EquidmentSo eqidItem = _bag.HandItem.Item.ItemInfor as EquidmentSo;
        if (eqidItem == null)
        {
            EventManger<string>.RaiseEvent("ShowNotifycation","Bạn phải có thuốc để chữa bệnh");
            return;
        }
        eqidItem.Used(_animal);
        _bag.HandItem.UseItem();
    }
    public void HarvestProductAnimal()
    {
        if (_bag.AddItem(ItemHelper.MappingItem(_animal.AnimalObject.Itemharvest)))
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

    public void InterRac(PlayerManager playerManager)
    {
        _uianimal.ShowUIinfor();
    }
}

