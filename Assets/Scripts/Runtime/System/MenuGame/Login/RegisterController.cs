using System;
using System.Text.RegularExpressions;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class RegisterController : MonoBehaviour
{
    
    public Action ActionRegisSuccess;
    public Action<string> AcionRegisFail;
    public void Register(string email, string password,string repassword)
    {
        if (!CheckInput(email, password, repassword))
        {
            OnrroFormat(email,password,repassword);
            return;
        }
        var request = new RegisterPlayFabUserRequest
        {
            Email = email,
            Password = password,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnSuccess, Onerror);
    }
    private void Onerror(PlayFabError result)
    {
            Debug.Log(result.ToString());
           AcionRegisFail?.Invoke("Erro don't known");
        
    }

    private void OnrroFormat(string email, string password,string repassword)
    {
        AcionRegisFail.Invoke(ShowMessErro(email,  password, repassword));   
    }
    private void OnSuccess(RegisterPlayFabUserResult obj)
    {
        ActionRegisSuccess?.Invoke();
    }
    public bool CheckInput(string email, string password,string reppassword)
    {
        string regexPattern = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
        if (!Regex.IsMatch(email, regexPattern)) return false;
        if (!reppassword.Equals(password)) return false;
        return true;
    }
    public string ShowMessErro(string email, string password,string reppassword)
    {
        string regexPattern = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
        if (!Regex.IsMatch(email, regexPattern)) return "Sai Dinh Dang Email";
        if (!reppassword.Equals(password)) return "Hai Mat Khau Khong Giong Nhau";
        return "";
    }
    
}
