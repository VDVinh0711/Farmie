using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SelectorBodyPart : MonoBehaviour
{
    public List<BodyPartSelector> BodyPartSelectors;
    [SerializeField] private BodypartController _bodypartController;
    [SerializeField] private ModelPlayer _modelPlayer;
    private bool OnValidateIndex(int index)
    {
        return index >= 0 && index <= BodyPartSelectors.Count;
    }
    public void NextPartBody(int index)
    {
        if(!OnValidateIndex(index)) return;
        int indexAfter = BodyPartSelectors[index].currentIndex + 1;
        BodyPartSelectors[index].currentIndex = indexAfter > BodyPartSelectors[index].SoBodyParts.Count - 1 ? 0 : indexAfter;
        UpdateCurrentPart(index);
        _bodypartController.UpdateBodyPart();
    }
    public void PreviousPartbody(int index)
    {
        if(!OnValidateIndex(index)) return;
        int indexAfter = BodyPartSelectors[index].currentIndex--;
        BodyPartSelectors[index].currentIndex = indexAfter < 0 ?  BodyPartSelectors[index].SoBodyParts.Count - 1  : indexAfter;
        UpdateCurrentPart(index);
       _bodypartController.UpdateBodyPart();
    }
    public void UpdateCurrentPart(int index)
    {
        _modelPlayer.Set(BodyPartSelectors[index].Type , BodyPartSelectors[index].GetBodyparCurrenIndex() );
    }
}

[Serializable]
public class BodyPartSelector
{
    public PartPlayerType Type;
    public int currentIndex;
    public List<SO_body_part> SoBodyParts;

    public SO_body_part GetBodyparCurrenIndex( )
    {
        return SoBodyParts[currentIndex];
    }
}