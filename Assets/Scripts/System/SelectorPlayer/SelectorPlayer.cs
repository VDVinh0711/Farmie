using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.U2D.Animation;

public class SelectorPlayer : MonoBehaviour
{
    [SerializeField] private List<SelectorItemDiction> _listPartSelector = new ();
    [SerializeField] private ModelPlayerManager _modelPlayerManager;
    public Action ActionChangeSelector;
    public List<SelectorItemDiction> ListSelector => _listPartSelector;
    private void Start()
    {
        OnSetSelectorPlayer();
        UpDateModelForPlayer();
    }
    public void NextPart(BodyPartType type)
    {
        foreach (var parSelector in _listPartSelector)
        {
            if(parSelector.type != type) continue;
            var resultindex = parSelector.currentIndex + 1;
            parSelector.currentIndex = resultindex > parSelector.GetLengthPart() ? 0 : resultindex;
        }
        UpDateModelForPlayer();
        OnStateChangeUISelector();
    }
    public void PreviousPart( BodyPartType type)
    {
        foreach (var parSelector in _listPartSelector)
        {
            if(parSelector.type != type) continue;
            var resultindex = parSelector.currentIndex - 1;
            parSelector.currentIndex = resultindex < 0 ? parSelector.GetLengthPart() : resultindex;
        }
        UpDateModelForPlayer();
        OnStateChangeUISelector();
    }
    private void UpDateModelForPlayer()
    {
        foreach (var patrSelector in _listPartSelector)
        {
            _modelPlayerManager.SetPartPlayer( patrSelector.GetPartPlayer());
        }
    }
    private void OnSetSelectorPlayer()
    {
        foreach (var parselector in _listPartSelector)
        {
            foreach (var partPlayer in _modelPlayerManager.ListPartPlayers)
            {
                if(parselector.type != partPlayer.type || partPlayer.partPlayer == null) continue;
                parselector.SetcurrentIndexFollowPart(partPlayer.partPlayer);
            }
        }

        OnStateChangeUISelector();
    }
    public void OnStateChangeUISelector()
    {
        ActionChangeSelector?.Invoke();
    }
    
    
}


[Serializable]
public class SelectorItemDiction
{
    public BodyPartType type;
    public int currentIndex;
    public List<PartPlayerModel_SO> listParts = new() ;

    public int GetLengthPart()
    {
        return listParts.Count - 1;
    }

    public PartPlayerModel_SO GetPartPlayer()
    {
        return listParts[currentIndex];
    }

    public void SetcurrentIndexFollowPart(PartPlayerModel_SO partPlayerModelSo)
    {
        for (int i = 0; i < listParts.Count; i++)
        {
            if(listParts[i].ID != partPlayerModelSo.ID) continue;
            currentIndex = i;
            break;
        }
    }
}
