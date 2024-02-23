using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Map : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private string _nameMap;
    [SerializeField] private ChoseMapManager _choseMapManager;
    public void OnPointerClick(PointerEventData eventData)
    {
        _choseMapManager.loadMapChosing("FarmScene");
    }
}
