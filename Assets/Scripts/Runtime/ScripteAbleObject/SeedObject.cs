
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "New ItemData/Seed")]
public class SeedObject : EquidmentObject,IStackAble
{
    [SerializeField]
    private int _daytoGrow;
    [SerializeField]
    private List<Sprite> _spriteGrow;
    [SerializeField]
    private ItemObject _itemHarvset;

    public int DaytoGrow => _daytoGrow;
    public List<Sprite> SpriteGrow => _spriteGrow;
    public ItemObject ItemHarvest => _itemHarvset;

    public override void Used(UnityEngine.Object data)
    {
        var land = data as Land;
        if(land == null) return;
        EventManger<SeedObject>.RaiseEvent("Planting seed" + land.ID,this);
    }


     [SerializeField] public int MaxStack { get => 30; }
}
