
using InventorySystem;
using UnityEngine;


public class CropBehavious : MonoBehaviour
{
    
    [SerializeField] private int _spriteNumber;
    [SerializeField] private float _curentTimeGrow;
    [SerializeField] SeedSo _seedData;
    [SerializeField] private SpriteRenderer _displayPlant;
    public SeedSo SeedData { get; set; }
    public string IDSeed => _seedData.ID;
    public int Sprite { get; set; }
  
    public float CurentTimeGrow => _curentTimeGrow;
    private void Awake()
    {
        _displayPlant = transform.GetComponentInChildren<SpriteRenderer>();
        
    }
    
    public void LoadCrop(SeedSo seed, int numbersprite, GameTime timeLoad)
    {
        _seedData = seed;
        var spriteAdd = (int)(GameTime.CompareGameTime(timeLoad, TimeManager.Instance.GetGameTime()) / TimetoGrow());
        var sprite = Mathf.Clamp(numbersprite + spriteAdd, 0, _seedData.SpriteGrow.Count - 1);
        _spriteNumber = sprite;
    }
    private float TimetoGrow()
    {
        return GameTime.MinutetoSecond(_seedData.DaytoGrow) / _seedData.SpriteGrow.Count;
    }
    public void Plant(SeedSo seedtoGrow)
    {
        _seedData = seedtoGrow;
    }
    public bool Harvest(Bag bag)
    {
        if (_displayPlant.sprite != _seedData.SpriteGrow[_seedData.SpriteGrow.Count - 1])
        {
            EventManger<string>.RaiseEvent("ShowNotifycation","Cây bạn chưa đủ lớn để thu hoạch");
            return false;
        }
        if (!bag.AddItem( ItemHelper.MappingItem(_seedData.ItemHarvest,1), 1)) return false;
        EventManger<Object>.RaiseEvent("CheckMission",_seedData.ItemHarvest);
        Destroy(gameObject);
        bag.HandItem.UseItem();
        return true;
    }
    public void Grow(Land.LandStatus landStatus)
    {
        if (_displayPlant.sprite != null)
        {
            Vector3 parentPosition = transform.parent.position;
            Vector2 spriteSize = _displayPlant.sprite.bounds.size;
            transform.position = new Vector2(parentPosition.x, parentPosition.y + (spriteSize.y/3.5f));
        }
        if (_spriteNumber < 0 || _spriteNumber > _seedData.SpriteGrow.Count - 1) return;
        _displayPlant.sprite = _seedData.SpriteGrow[_spriteNumber];
        _curentTimeGrow = landStatus == Land.LandStatus.soilwater ? _curentTimeGrow += 2 : _curentTimeGrow += 1;
        if (_curentTimeGrow < TimetoGrow()) return;
        _curentTimeGrow = 0;
        _spriteNumber++;
    }
}
