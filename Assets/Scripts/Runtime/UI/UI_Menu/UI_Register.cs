using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Register : MonoBehaviour,IAnimationUI
{

    #region  Variable

    [SerializeField] private RegisterController _registerController;
    [Header("Input")]
    [SerializeField] private Transform parentInput;
    [SerializeField] private TMP_InputField _inputUser;
    [SerializeField] private TMP_InputField _inputPasswork;
    [SerializeField] private TMP_InputField _inputRePasswork;
    [SerializeField] private TMP_InputField _inputEmail;

    [Header("Notifycation")]
    [SerializeField]private RectTransform _panleNotify;
    [SerializeField] private TextMeshProUGUI _notifycation;
    [SerializeField] private Button _buttonNotify;
    [Header("Button")]
    [SerializeField] private Transform rootButton;
    [SerializeField] private Button _buttonBack;
    [SerializeField] private Button _buttonRegister;
   
    
    private Dictionary<string, Vector3> listRootPosOBj = new();
    [SerializeField] private UI_Menu_Manager _uiMenuManager;

    #endregion
    

    private void Awake()
    {
        LoadPosRoot();
        RegisterEnvent();
    }




    private void SetNotifycationText(string text)
    {
        _notifycation.SetText(text);
    }
    private void DeActiveNotify()
    {
        if (!_panleNotify.gameObject.activeSelf) return;
          _panleNotify.gameObject.SetActive(false);
    }
    private void OnNotifycationFail(string text)
    {
        ActiveNotifycation();
        _notifycation.SetText(text);
        _buttonNotify.onClick.RemoveAllListeners();
        _buttonNotify.onClick.AddListener(OnButtonOKFail);
    }
    private void OnregisterSucces()
    {
        ActiveNotifycation();
        SetNotifycationText("Register Done");
        _buttonNotify.onClick.RemoveAllListeners();
        _buttonNotify.onClick.AddListener(OnButtonOkSuces);
    }
    private void ActiveNotifycation()
    {
        _panleNotify.gameObject.SetActive(true);
       
    }
    private void OnButtonOKFail()
    {
        ReText();
        DeActiveNotify();
    }

    private void OnButtonOkSuces()
    {
        DeActiveNotify();
        OnButtonBack();
    }

    private void ReText()
    {
        _inputUser.text = "";
        _inputPasswork.text = "";
        _inputRePasswork.text = "";
        _inputEmail.text = "";
    }
    #region Button & Event
    private void RegisterEnvent()
    {
        _buttonBack.onClick.AddListener(OnButtonBack);
        _buttonRegister.onClick.AddListener(OnButtonRegis);
        _registerController.AcionRegisFail -= OnNotifycationFail;
        _registerController.AcionRegisFail += OnNotifycationFail;
        _registerController.ActionRegisSuccess -= OnregisterSucces;
        _registerController.ActionRegisSuccess += OnregisterSucces;
        
    }
    public void OnButtonRegis()
    {
        string username = _inputUser.text;
        string password = _inputUser.text;
        string repassword = _inputUser.text;
        string email = _inputEmail.text;
        _registerController.Register(username.Trim() , password.Trim() , repassword.Trim() , email.Trim());
    }
    public void OnButtonBack()
    {
        _uiMenuManager.HideUiMenugame(this.transform);
    }
    #endregion
    
   

    #region AnimationUI
    private void LoadPosRoot()
    {
        foreach (var input in parentInput.GetComponentsInChildren<TMP_InputField>())
        {
            listRootPosOBj[input.name] = input.gameObject.transform.position;
        }
        foreach (var input in rootButton.GetComponentsInChildren<Button>())
        {
            listRootPosOBj[input.name] = input.gameObject.transform.position;
        }

    }
    public void AnimationIn()
    {
      
        _inputUser.gameObject.SetActive(true);
        _inputUser.gameObject.transform.DOMove(listRootPosOBj[_inputUser.name], 1);
         
        _inputPasswork.gameObject.SetActive(true);
        _inputPasswork.gameObject.transform.DOMove(listRootPosOBj[_inputPasswork.name], 1);
        
        _inputEmail.gameObject.SetActive(true);
        _inputEmail.gameObject.transform.DOMove(listRootPosOBj[_inputEmail.name], 1);
         
        _inputRePasswork.gameObject.SetActive(true);
        _inputRePasswork.gameObject.transform.DOMove(listRootPosOBj[_inputRePasswork.name], 1);
         
        _buttonBack.gameObject.SetActive(true);
        _buttonBack.gameObject.transform.DOMove(listRootPosOBj[_buttonBack.name], 1);
         
        _buttonRegister.gameObject.SetActive(true);
        _buttonRegister.gameObject.transform.DOMove(listRootPosOBj[_buttonRegister.name], 1);
    }
    public void AnimationOut()
    {
         
        foreach (var input in parentInput.GetComponentsInChildren<TMP_InputField>())
        {
            input.gameObject.SetActive(false);
            input.gameObject.transform.DOLocalMove(new Vector3(listRootPosOBj[input.name].x,listRootPosOBj[input.name].y+50 , 0), 1);
        }
        foreach (var input in rootButton.GetComponentsInChildren<Button>())
        {
            input.gameObject.SetActive(false);
            input.gameObject.transform.DOLocalMove(new Vector3(listRootPosOBj[input.name].x,listRootPosOBj[input.name].y+50 , 0), 1);
        }
    }
    #endregion

     
     
    
}
