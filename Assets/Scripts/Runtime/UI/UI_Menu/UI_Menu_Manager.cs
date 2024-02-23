
using System;
using System.Collections.Generic;
using UnityEngine;

public class UI_Menu_Manager : MonoBehaviour
{
    [SerializeField] private UI_Mainmenu _uiMainmenu;
    [SerializeField] private UI_Setting _uiSetting;
    [SerializeField] private UI_Login _uiLogin;
    [SerializeField] private UI_Register _uiRegister;
    
    
     public UI_Mainmenu UI_Mainmenu =>_uiMainmenu;
     public UI_Setting UI_Setting =>_uiSetting;
     public UI_Login UI_Login =>_uiLogin;
     public UI_Register UI_Register =>_uiRegister;
    
     
    private Stack<Transform> _stackUIMenu = new();
    private void Start()
    {
        OpenUiMenuGame(_uiMainmenu.gameObject.transform);
    }

    public void OpenUiMenuGame(Transform ui)
    {
        if (_stackUIMenu.Count != 0)
        {
            _stackUIMenu.Peek().GetComponent<IAnimationUI>().AnimationOut();
            _stackUIMenu.Peek().gameObject.SetActive(false);
        }
        if (ui.GetComponent<UI_Mainmenu>() != null)
        {
            _stackUIMenu.Clear();
        }
        ui.gameObject.SetActive(true);
        ui.gameObject.GetComponent<IAnimationUI>().AnimationIn();
        _stackUIMenu.Push(ui);
    }

    public void HideUiMenugame(Transform ui)
    {
        print(ui.gameObject.name);
        print(_stackUIMenu.Peek() != ui);
       // if(_stackUIMenu.Peek() != ui) return;
        _stackUIMenu.Peek().GetComponent<IAnimationUI>().AnimationOut();
        _stackUIMenu.Peek().gameObject.SetActive(false);
        print(_stackUIMenu.Peek().transform.name);
        print(_stackUIMenu.Count);
        _stackUIMenu.Pop();
        print(_stackUIMenu.Count);
        print(_stackUIMenu.Contains(ui));
        OpenUiMenuGame(_stackUIMenu.Peek());
        
    }

}
