using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Setting : MonoBehaviour,IAnimationUI
{
    [SerializeField] private Slider musicvolume;
    [SerializeField] private Slider sfxvomume;
    [SerializeField] private Button _btnExit;
    [SerializeField] private Button _btnMusic;
    [SerializeField] private Button _btnSFX;
    [SerializeField] private RectTransform _panelSetting;
    [SerializeField] private UI_Menu_Manager _uiMenuManager;
    private Vector3 _startPos;
    
   

    private void Awake()
    {
        _startPos = _panelSetting.transform.position;
       
    }
    private void Start()
    {
        RegisterEvent(); 
    }
    
    private void RegisterEvent()
    {
        musicvolume.onValueChanged.AddListener(ChangeVolumeMusic);
        sfxvomume.onValueChanged.AddListener(ChangeVolumeVfx);
        _btnMusic.onClick.AddListener(BtnMusicClick);
        _btnSFX.onClick.AddListener(BtnSfxClick);
        _btnExit.onClick.AddListener(HidePanelSetting);
    }
    private void ChangeVolumeMusic(float value)
    {
        GameManager.Instance.SoundGameManager.SetValueMusic(value);
    }

    private void ChangeVolumeVfx(float value)
    {
        GameManager.Instance.SoundGameManager.SetValueSFX(value);
    }
    
    private void BtnMusicClick()
    {
        musicvolume.value = 0;
    }
    private void BtnSfxClick()
    {
        sfxvomume.value = 0;
    }
    public void ShowPanelSetting()
    {
        UIManager.OpenUI(_panelSetting);
    }
    private void HidePanelSetting()
    {
       _uiMenuManager.HideUiMenugame(_panelSetting);
    }
    public void AnimationIn()
    {
        _panelSetting.gameObject.SetActive(true);
        _panelSetting.gameObject.transform.DOLocalMove(_startPos,1);
    }
    public void AnimationOut()
    {
        _panelSetting.transform.DOLocalMove(new Vector3(_startPos.x - 200, _startPos.y, 0), 1);
        _panelSetting.gameObject.SetActive(false);
    }
    
}
