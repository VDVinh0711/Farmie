using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Register : MonoBehaviour,IAnimationUI
{

    [Header("Input")]
    [SerializeField] private Transform parentInput;
    [SerializeField] private TMP_InputField _inputUser;
    [SerializeField] private TMP_InputField _inputPasswork;
    [SerializeField] private TMP_InputField _inputRePasswork;
    [SerializeField] private TextMeshProUGUI _notifycation;

    [Header("Button")]
    [SerializeField] private Transform rootButton;

    [SerializeField] private Button _buttonBack;
    [SerializeField] private Button _buttonRegister;
    private Dictionary<string, Vector3> listRootPosOBj = new();
    [SerializeField] private UI_Menu_Manager _uiMenuManager;
    


    private void Awake()
    {
        LoadPosRoot();
    }

    private void Start()
    {
        _buttonBack.onClick.AddListener(OnButtonBack);
        _buttonRegister.onClick.AddListener(OnButtonRegis);
    }


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

    public void OnButtonRegis()
    {
        string email = _inputUser.text;
        string passwork = _inputUser.text;
        string repasswork = _inputUser.text;
        if (passwork != repasswork)
        {
            _notifycation.text = "Passwork khong giong";
            return;
        }

        RegisterAccount registerAccount = new RegisterAccount();
        registerAccount.Register(email,passwork);

    }

    public void OnButtonBack()
    {
        _uiMenuManager.HideUiMenugame(this.transform);
    }



     public void AnimationIn()
     {
      
         _inputUser.gameObject.SetActive(true);
         _inputUser.gameObject.transform.DOMove(listRootPosOBj[_inputUser.name], 1);
         
         _inputPasswork.gameObject.SetActive(true);
         _inputPasswork.gameObject.transform.DOMove(listRootPosOBj[_inputPasswork.name], 1);
         
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
     
    
}
