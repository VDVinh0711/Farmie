
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Menu_Ingame : AbsCheckOutSide
{

    [SerializeField] private Button _btn_ShowMenu;
    [SerializeField] private Button _btn_Resume;
    [SerializeField] private Button _btn_Save;
    [SerializeField] private Button _btn_Setting;
    [SerializeField] private Button _btn_Exit;
    [SerializeField] private Transform _pannelMenu;
    
  
    
    void Start()
    {
        GetComponent();
        RegisterEvent();
    }
    private void GetComponent()
    {
        _btn_ShowMenu = transform.GetComponent<Button>();
        _pannelMenu = transform.GetChild(0).transform;
        _btn_Resume = _pannelMenu.GetChild(0).GetComponent<Button>();
        _btn_Save = _pannelMenu.GetChild(1).GetComponent<Button>();
        _btn_Setting = _pannelMenu.GetChild(2).GetComponent<Button>();
        _btn_Exit = _pannelMenu.GetChild(3).GetComponent<Button>();
    }

    private void RegisterEvent()
    {
        _btn_Resume.onClick.AddListener(Resume);
        _btn_Save.onClick.AddListener(ChoseMap);
        _btn_ShowMenu.onClick.AddListener(TurnMenu);
        _btn_Exit.onClick.AddListener(Exit);
        _btn_Setting.onClick.AddListener(Setting);
        
    }
    private void Resume()
    {
        HideMenu();
    }

    private void ChoseMap()
    {
        SceneManager.LoadScene("ChoseMap");
    }

    private void Exit()
    {
        ChoseMap();
        HideMenu();
        LoadSceneHelper loadSceneHelper = FindObjectOfType<LoadSceneHelper>();
        loadSceneHelper.StarLoadSceneCouroutine("Menu");
    }

    private void ShowMenu()
    {
        UIManager.OpenUI(_pannelMenu);
       regisclick();
    }
    private void HideMenu()
    {
        UIManager.HideUI(_pannelMenu);
      RemoveClick();
        
    }

    public void TurnMenu()
    {
        if (_pannelMenu.gameObject.activeSelf)
        {
            HideMenu();
        }
        else
        {
            ShowMenu();
        }
    }

    private void Setting()
    {
        var settingobj = transform.GetChild(1);
        var ui_setting = settingobj.transform.GetComponent<UI_Setting>();
        ui_setting.ShowPanelSetting();
    }

   protected  override void Click(InputAction.CallbackContext obj)
    {
        if(!_isOutSide) return;
        HideMenu();
        _isOutSide = false;
    }
}
