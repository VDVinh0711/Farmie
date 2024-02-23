using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using  UnityEngine.UI;
using UnityEngine;
using DG.Tweening;


public class UI_Login : MonoBehaviour ,IAnimationUI
{
    
    
    [Header("Input")]
    [SerializeField] private TMP_InputField _inputUser;
    [SerializeField] private TMP_InputField _inputPasswork;
    [Header("Button")] 
    [SerializeField] private Button _btnLogin;
    [SerializeField] private Button _btnRegister;
    [SerializeField] private Button _btnForgorPas;
    [SerializeField] private Button _btnBack;
    [Header("Notifycation")] 
    [SerializeField] private TextMeshProUGUI _notifycation;
    [Header("Ui_Menu_Manager")] 
    [SerializeField] private UI_Menu_Manager _uiMenuManager;

    [SerializeField] private LoadSceneHelper _loadSceneHelper;

    private Dictionary<string, Vector3> posRootOBj;

    private void Awake()
    {
        LoadrootPosOBJ();
    }

    private void Start()
    {
        RegisterEnventButton();
    }
    private void RegisterEnventButton()
    {
        _btnLogin.onClick.AddListener(OnButtonLoginClick);
        _btnRegister.onClick.AddListener(OnButtonRegster);
        _btnForgorPas.onClick.AddListener(OnButtonGetPasswork);
        _btnBack.onClick.AddListener(OnButtonBack);
    }
    private void LoadrootPosOBJ()
    {
        posRootOBj = new Dictionary<string, Vector3>();
        
        posRootOBj[_inputUser.name] =  _inputUser.transform.position ;
        _inputUser.gameObject.SetActive(false);
        
        posRootOBj[_inputPasswork.name] = _inputPasswork.transform.position;
        _inputPasswork.gameObject.SetActive(false);
        
        /*posRootOBj[_btnLogin.name] = _btnLogin.transform.position;
        _btnLogin.gameObject.SetActive(false);*/
        
        /*posRootOBj[_btnRegister.name] = _btnRegister.transform.position;
        _btnRegister.gameObject.SetActive(false);
        
        posRootOBj[_btnForgorPas.name] = _btnForgorPas.transform.position;
        _btnForgorPas.gameObject.SetActive(false);
        
        posRootOBj[_btnBack.name] = _btnBack.transform.position;
        _btnBack.gameObject.SetActive(false);*/
    }
    
    private void NotifycationLogin(string text)
    {
        if(text == null) return;
        _notifycation.SetText(text);
    }
    
    private void LoginSucess()
    {
        _loadSceneHelper.StarLoadSceneCouroutine("ChoseMap");
    }

    public void OnButtonLoginClick()
    {
        string userEmail = _inputUser.text;
        string passwork = _inputPasswork.text;
        LoginSystem loginSystem = new LoginSystem(LoginSucess,NotifycationLogin);
        loginSystem.Login(userEmail, passwork);
    }

    public void OnButtonRegster()
    {
        _uiMenuManager.OpenUiMenuGame(_uiMenuManager.UI_Register.transform);
    }
    public void OnButtonBack()
    {
        _uiMenuManager.OpenUiMenuGame(_uiMenuManager.UI_Mainmenu.transform);
    }

    public void OnButtonGetPasswork()
    {
       
    }
    public void AnimationIn()
    {
        _inputUser.gameObject.SetActive(true);
        _inputUser.transform.DOLocalMove(posRootOBj[_inputUser.name], 1);
        
        _inputPasswork.gameObject.SetActive(true);
        _inputPasswork.transform.DOLocalMove(posRootOBj[_inputPasswork.name], 1);
        
        /*_btnBack.gameObject.SetActive(true);
        _btnBack.transform.DOLocalMove(posRootOBj[_btnBack.name], 1);*/
        
        /*_btnLogin.gameObject.SetActive(true);
        _btnLogin.transform.DOLocalMove(posRootOBj[_btnLogin.name], 1);*/
        
        /*_btnRegister.gameObject.SetActive(true);
        _btnRegister.transform.DOLocalMove(posRootOBj[_btnRegister.name], 1);

        _btnForgorPas.gameObject.SetActive(true);
        _btnForgorPas.transform.DOLocalMove(posRootOBj[_btnForgorPas.name], 1);*/
    }
    public void AnimationOut()
    {
        _inputUser.transform.DOLocalMove(new Vector3(posRootOBj[_inputUser.name].x , posRootOBj[_inputUser.name].y-400,0), 1);
        _inputPasswork.transform.DOLocalMove(new Vector3(posRootOBj[_inputPasswork.name].x , posRootOBj[_inputPasswork.name].y-400,0), 1);
       // _btnBack.transform.DOLocalMove(new Vector3(posRootOBj[_btnBack.name].x , posRootOBj[_btnBack.name].y+500,0), 1);
       // _btnLogin.transform.DOLocalMove(new Vector3(posRootOBj[_btnLogin.name].x , posRootOBj[_btnLogin.name].y+500,0), 1);
       // _btnRegister.transform.DOLocalMove(new Vector3(posRootOBj[_btnRegister.name].x , posRootOBj[_btnRegister.name].y+500,0), 1);
       // _btnForgorPas.transform.DOLocalMove(new Vector3(posRootOBj[_btnForgorPas.name].x , posRootOBj[_btnForgorPas.name].y+500,0), 1);
    }

  
    
}
