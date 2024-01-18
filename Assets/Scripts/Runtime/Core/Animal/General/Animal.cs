
using UnityEngine;



public class Animal : MonoBehaviour
{
    private AnimalObject _animal;
    public AnimalObject AnimalObject => _animal;
    [Header("Animal Controller")]
    private MoveAnimal moveAnimal;
    private PhysiologicalState _animalPhysiologicalState;
    private UiAnimal _uianimal;
    private Stable _stable;
    private AnimalBehavor _animalBehavor;
    private GrowAnimal _growAnimal;
    private AnimalInterac _animalInterac;
    private SoundAnimal _soundAnimal;
    private SellAnimal _sellAnimal;
    public MoveAnimal MoveAnimal => moveAnimal;
    public PhysiologicalState PhysiologicalState => _animalPhysiologicalState;
    public UiAnimal UiAnimal => _uianimal;
    public AnimalBehavor AnimalBehavor => _animalBehavor;
    public Stable Stable => _stable;
    public GrowAnimal GrowAnimal => _growAnimal;
    public AnimalInterac AnimalInterac => _animalInterac;
    public SoundAnimal SoundAnimal => _soundAnimal;
    public SellAnimal SellAnimal => _sellAnimal;
    public string ID => _animal.id;
    public bool IsNormal => _animalPhysiologicalState.IsNormal;
    public bool IsHarvest => _animalPhysiologicalState.IsHarvest;
    public bool IsSick => _animalPhysiologicalState.IsSick;
    public bool IsHurry => _animalPhysiologicalState.IsHurry;

    

    private void GetComponent()
    {
        _stable = transform.GetComponentInParent<Stable>();
        _animalBehavor = transform.GetComponent<AnimalBehavor>();
        _uianimal = transform.GetComponent<UiAnimal>();
        moveAnimal = transform.GetComponent<MoveAnimal>();
        _animalPhysiologicalState = GetComponent<PhysiologicalState>();
        _growAnimal = GetComponent<GrowAnimal>();
        _animalInterac = GetComponent<AnimalInterac>();
        _soundAnimal = GetComponent<SoundAnimal>();
        _sellAnimal = GetComponent<SellAnimal>();
    }
    public void Instantiate(AnimalObject animal)
    {
        GetComponent();
        _animal = animal;
        _animalPhysiologicalState.SetData(_animal.timetoEat,animal.health);
        
    }

    public void LoadDataAnimal(AnimalData animalData)
    {
        _growAnimal.TimeGrow = animalData.currentTime;
        _animalPhysiologicalState.IsHarvest = animalData.IsHarvest;
        _animalPhysiologicalState.IsNormal = animalData.Isnormal;
        _animalPhysiologicalState.IsHurry = animalData.ISHurry;
        _animalPhysiologicalState.IsSick = animalData.ISsick;

    }

    
}
