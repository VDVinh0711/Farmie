using System;
using InventorySystem;
using UnityEngine;
using UnityEngine.Serialization;


public class Land : MonoBehaviour,ITimeTracker, IInterac
{ 
    [SerializeField] private int _idLand;
    public enum LandStatus
    {
        soildefaut,
        soilwater,
        soidWilted
    }
     public  bool planting;
    [SerializeField] SpriteRenderer _rendererLand;
    [SerializeField] public LandStatus LandState;
    [SerializeField] private Material soildefaut, soilwater,soidwilted;
    [SerializeField] Transform select;
    public int ID
    {
        get => _idLand;
        set
        {
            _idLand = value;
        }
    }
    //Cache the time the land was Watered
    public GameTime lastTimeWatered;
    [SerializeField]  private Bag _inventorymanager;
    
    [Header("Crop")]
    private CropBehavious cropPlanted;
    [SerializeField]  GameObject cropPreFabs;

    
    private void Start()
    {
        _rendererLand = GetComponent<SpriteRenderer>();
        SwitchLand(LandState);
       
        TimeManager.Instance.RegisterTracker(this);
       
        
        EventManager.RegisterEvent("Watering" + _idLand,WateringPlant);
        EventManger<SeedObject>.Registerevent("Planting seed" + _idLand,SeedingPlant);
        EventManager.RegisterEvent("Harvest" + _idLand,Harvest);
    }
    
    public void SwitchLand(LandStatus status)
    {
        LandState = status;
        Material marterialtoSwitch = soildefaut;
        switch (status)
        {
            case LandStatus.soildefaut :
                marterialtoSwitch = soildefaut;
                break;
            case LandStatus.soilwater :
                marterialtoSwitch = soilwater;
                break;
            case LandStatus.soidWilted:
                marterialtoSwitch = soidwilted;
            break;

        }

        _rendererLand.material = marterialtoSwitch;
;
    }

    public void Select(bool toggel)
    {
        select.gameObject.SetActive(toggel);
    }
    public void InterRac()
    {
        if(_inventorymanager  == null) _inventorymanager = FindAnyObjectByType<Bag>();
        EquidmentObject eqidItem = _inventorymanager.HandItem.Item as EquidmentObject;
        if(eqidItem == null) return;
        eqidItem.Used(this);
        
    }

    private void WateringPlant()
    {
        SwitchLand(LandStatus.soilwater);
        lastTimeWatered = TimeManager.Instance.GetGameTime();
       _inventorymanager.HandItem.UseItem();
    }

    private void SeedingPlant(SeedObject seedObject)
    {
        if(planting == true) return;
        if(LandState != LandStatus.soilwater) return;
        planting = true;
        SpawmCrop();
        cropPlanted.Plant( seedObject);
       _inventorymanager.HandItem.UseItem();
    }

    private void Harvest()
    {
        if (cropPlanted.Harvest())
        {
            planting = false;
           
        }
    }
    // ReSharper disable Unity.PerformanceAnalysis
    public CropBehavious SpawmCrop()
    {
        GameObject cropObject = Instantiate(cropPreFabs, transform);
        cropPlanted = cropObject.transform.GetComponent<CropBehavious>();
        return cropPlanted;
    }
    public void CLockUpdate(GameTime gameTime)
    {
        if (LandState == LandStatus.soilwater)
        {
            int hourElapsed =  GameTime.CompareGameTime(lastTimeWatered, gameTime);
            if(hourElapsed >=10)
            {
               SwitchLand(LandStatus.soildefaut);
            }
        }
        if (cropPlanted == null) return;
        cropPlanted.Grow(LandState);
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener("Watering"+ _idLand,WateringPlant);
        EventManger<SeedObject>.Removeevent("Planting seed" + _idLand,SeedingPlant);
        EventManager.RemoveListener("Harvest" + _idLand,Harvest);
    }
}
