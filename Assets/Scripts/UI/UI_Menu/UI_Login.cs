using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using  UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;


public class UI_Login : MonoBehaviour ,IAnimationUI
{
    #region Variable

    [SerializeField] private LoginCotroller _loginCotroller;
    [Header("Input")]
    [SerializeField] private TMP_InputField _inputUser;
    [SerializeField] private TMP_InputField _inputPassword;
    
    [Header("Button")] 
    [SerializeField] private Button _btnLogin;
    [SerializeField] private Button _btnRegister;
    [SerializeField] private Button _btnForgorPas;
    [SerializeField] private Button _btnBack;

    [Header("Notifycation")] 
    [SerializeField] private RectTransform _panelNotify;
    [SerializeField] private TextMeshProUGUI _notifycation;
    [Header("Ui_Menu_Manager")] 
    [SerializeField] private UI_Menu_Manager _uiMenuManager;
    private Dictionary<string, Vector3> posRootOBj;

    #endregion
    private void Awake()
    {
        LoadrootPosOBJ();
        _loginCotroller.AcionloginFail -= LoginFail;
        _loginCotroller.AcionloginFail += LoginFail;
        _loginCotroller.ActionloginSuccess -= LoginSuccess;
        _loginCotroller.ActionloginSuccess += LoginSuccess;
    }
    private void Start()
    {
        RegisterEnvent();
    }
    
    private void LoginFail(string text)
    {
        print("call this");
        _panelNotify.gameObject.SetActive(true);
        _notifycation.SetText(text);
        _inputPassword.text = "";
    }

    private void LoginSuccess()
    {
        _panelNotify.gameObject.SetActive(true);
        _notifycation.SetText("Login Success");
    }
    private void DeActiveNotify()
    {
        if (_panelNotify.gameObject.activeSelf)
        {
            _panelNotify.gameObject.SetActive(false);
        }
    }
    #region Button & Event

    private void OnButtonLoginClick()
    {
        string userEmail = _inputUser.text;
        string passwork = _inputPassword.text;
        _loginCotroller.Login(userEmail,passwork);
     
    }
    public void OnButtonRegster()
    {
        _uiMenuManager.OpenUiMenuGame(_uiMenuManager.UI_Register.transform);
    }
    private void OnButtonBack()
    {
        _uiMenuManager.OpenUiMenuGame(_uiMenuManager.UI_Mainmenu.transform);
    }
    private void OnButtonGetPasswork()
    {
       
    }
    private void RegisterEnvent()
    {
        _btnLogin.onClick.AddListener(OnButtonLoginClick);
        _btnRegister.onClick.AddListener(OnButtonRegster);
        _btnForgorPas.onClick.AddListener(OnButtonGetPasswork);
        _btnBack.onClick.AddListener(OnButtonBack);
        _inputPassword.onSelect.AddListener((arg0 =>{_inputPassword.text = ""; DeActiveNotify(); } ));
        _inputUser.onSelect.AddListener((arg0 =>{ DeActiveNotify();} ));
    }

    #endregion
    #region SetAnimationFor UI

    private void LoadrootPosOBJ()
    {
        posRootOBj = new Dictionary<string, Vector3>();
        posRootOBj[_inputUser.name] =  _inputUser.transform.position ;
        _inputUser.gameObject.SetActive(false);
        posRootOBj[_inputPassword.name] = _inputPassword.transform.position;
        _inputPassword.gameObject.SetActive(false);
    }
    public void AnimationIn()
    {
        _inputUser.gameObject.SetActive(true);
        _inputUser.transform.DOLocalMove(posRootOBj[_inputUser.name], 1);
        
        _inputPassword.gameObject.SetActive(true);
        _inputPassword.transform.DOLocalMove(posRootOBj[_inputPassword.name], 1);
    }
    public void AnimationOut()
    {
        _inputUser.transform.DOLocalMove(new Vector3(posRootOBj[_inputUser.name].x , posRootOBj[_inputUser.name].y-400,0), 1);
        _inputPassword.transform.DOLocalMove(new Vector3(posRootOBj[_inputPassword.name].x , posRootOBj[_inputPassword.name].y-400,0), 1);
    }

    #endregion
    

  
    
    
}
