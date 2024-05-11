using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SelectorPlayer : MonoBehaviour
{
    [Header("Button Next")]
    [SerializeField] private List<DictionButon> _dictionButonsNexts;
    [Header("Button Previous")]
    [SerializeField] private List<DictionButon> _dictionButonsPres;
    [Header("TextMeshPro")]
    [SerializeField] private List<DictionTextMesh> _dictionTextMeshs;


    [SerializeField] private SelectorPlayer _selectorPlayer;


    private void Awake()
    {
        _selectorPlayer.ActionChangeSelector -= SetTextMesh;
        _selectorPlayer.ActionChangeSelector += SetTextMesh;
        ResigerEventButtonPrevious();
        ResigerEventButtonNext();
    }

    private void Start()
    {
        SetTextMesh();
    }
    
    private void ResigerEventButtonNext()
    {
        foreach (var buttonNext in _dictionButonsNexts)
        {
            buttonNext.Button.onClick.AddListener((() => _selectorPlayer.NextPart(buttonNext.Type)));
        }
    }
    private void ResigerEventButtonPrevious()
    {
        foreach (var buttonPre in _dictionButonsPres)
        {
            buttonPre.Button.onClick.AddListener(() =>_selectorPlayer.PreviousPart(buttonPre.Type));
        }
    }
    private void SetTextMesh()
    {
        foreach (var textMesh in _dictionTextMeshs)
        {
            foreach (var selector in _selectorPlayer.ListSelector)
            {
               if(textMesh.Type != selector.type) continue;
               textMesh.Textmesh.SetText(selector.GetPartPlayer().NamePart);
            }
        }
    }
}
[Serializable]
public class DictionButon
{
    public BodyPartType Type;
    public Button Button;
}
[Serializable]
public class DictionTextMesh
{
    public BodyPartType Type;
    public TextMeshProUGUI Textmesh;
}
