
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "New ItemData/ItemClothes")]
public class ClothesItemSO : ItemObject
{
    
    public SO_body_part SoBodyPart;
    public PartPlayerType partPlayerType;
    public int LevelRequired;
}


public enum PartPlayerType
{
    Hat,
    Shirt,
    Pain,
    Shoes,
    Body,
    Hair,
    Torso,
    Legs
}
