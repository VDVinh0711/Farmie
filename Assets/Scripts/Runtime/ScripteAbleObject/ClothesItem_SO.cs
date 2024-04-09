using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;


[CreateAssetMenu(menuName = "New ItemData/Clothes Item")]
public class ClothesItem_SO : Item_SO
{
   [SerializeField] public CLothesType Type;
   [SerializeField] public SpriteLibraryAsset SpriteLibraryAsset;
}
