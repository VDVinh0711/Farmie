using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class ModelPlayer : MonoBehaviour
{
    [Header("PartPlayer")]
    [SerializeField] private List<DictionPartsPlayer> _parsPlayer = new ();
    [Header("ClothesPlayer")]
    [SerializeField] private List<DictionClothesPlayer> _clothesPlayers = new();
    [Header("SpriteAssetNone")] 
    [SerializeField] private SpriteLibraryAsset _partNone;
    [SerializeField] private SpriteLibraryAsset _clothesNone;
    public virtual void SetPartPlayer(BodyPartType type, PartPlayerModel_SO partPlayerModelSo)
    {
        foreach (var modelplayer in _parsPlayer)
        {
            if(modelplayer.Type != type) continue;
            var spriteadd = partPlayerModelSo == null ? _partNone : partPlayerModelSo.SpriteLibraryAsset;
            modelplayer.SpriteLib.spriteLibraryAsset = spriteadd;
        }
    }
    public virtual void SetClothesPlayer(CLothesType type, ClothesItem_SO clothesItemSo)
    {
        foreach (var clothesPlayer in _clothesPlayers)
        {
            if(clothesPlayer.Type != type) continue;
            var spriteAdd = clothesItemSo == null ? _clothesNone : clothesItemSo.SpriteLibraryAsset;
            clothesPlayer.SpriteLib.spriteLibraryAsset = spriteAdd;
        }
    }
}

[Serializable]
public class DictionPartsPlayer
{
    public BodyPartType Type;
    public SpriteLibrary SpriteLib;
}
[Serializable]
public class DictionClothesPlayer
{
    public CLothesType Type;
    public SpriteLibrary SpriteLib;
}

