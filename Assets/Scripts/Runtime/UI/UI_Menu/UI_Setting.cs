using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Setting : MonoBehaviour,IPointerExitHandler,IPointerEnterHandler
{
    [SerializeField] private Slider musicvolume;
    [SerializeField] private Slider sfxvomume;
    [SerializeField] private Button _btnExit;
    [SerializeField] private Button _btnMusic;
    [SerializeField] private Button _btnSFX;
    [SerializeField] private RectTransform _panelSetting;

 


    private bool checkoutSide = false;
    

    private void Start()
    {
        GetComponent();
        RegisterEvent();
    }

    private void GetComponent()
    {
        _panelSetting = transform.GetChild(0).GetComponent<RectTransform>();
        _btnExit = _panelSetting.GetChild(3).GetComponent<Button>();
        musicvolume = _panelSetting.GetChild(1).GetComponentInChildren<Slider>();
        _btnMusic = _panelSetting.GetChild(1).GetComponentInChildren<Button>();
        sfxvomume = _panelSetting.GetChild(2).GetComponentInChildren<Slider>();
        _btnSFX = _panelSetting.GetChild(2).GetComponentInChildren<Button>();
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
        UIManager.HideUI(_panelSetting);
    }
    
    
    private void LateUpdate()
    {
        if(!_panelSetting.gameObject.activeSelf) return;
        if (Input.GetMouseButtonDown(0))
        {
            if (checkoutSide)
            {
                HidePanelSetting();
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        checkoutSide = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        checkoutSide = false;
    }
    
}
