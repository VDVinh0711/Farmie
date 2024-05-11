using System;
using InventorySystem;
using Player;
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
    public int ID { get; set; }
    //Cache the time the land was Watered
    public GameTime lastTimeWatered;
    [SerializeField]  private Bag _bag;
    
    [Header("Crop")]
    private CropBehavious cropPlanted;
    [SerializeField]  GameObject cropPreFabs;
    
    private void Start()
    {
        _rendererLand = GetComponent<SpriteRenderer>();
        SwitchLand(LandState);
        TimeManager.Instance.RegisterTracker(this);
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
    public void WateringPlant()
    {
        SwitchLand(LandStatus.soilwater);
        lastTimeWatered = TimeManager.Instance.GetGameTime();
       _bag.HandItem.UseItem();
    }
    public void SeedingPlant(SeedSo seedSo)
    {
        if(planting == true) return;
        if(LandState != LandStatus.soilwater) return;
        planting = true;
        SpawmCrop();
        cropPlanted.Plant( seedSo);
       _bag.HandItem.UseItem();
    }
    public void Harvest()
    {
        if (cropPlanted.Harvest(_bag)) planting = false;
    }
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
        EventManger<SeedSo>.Removeevent("Planting seed" + _idLand,SeedingPlant);
        EventManager.RemoveListener("Harvest" + _idLand,Harvest);
    }
    public void InterRac(PlayerManager playerManager)
    {
        _bag  = playerManager.Bag;
        if(!_bag.HandItem.HasItem()) return;
        EquidmentSo eqidItem = _bag.HandItem.Item.ItemInfor as EquidmentSo;
        if(eqidItem == null) return;
        eqidItem.Used(this);
    }
}
