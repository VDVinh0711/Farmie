using System;
using System.Text.RegularExpressions;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class RegisterController : MonoBehaviour
{
    
    public Action ActionRegisSuccess;
    public Action<string> AcionRegisFail;
    public void Register(string usename, string email, string password,string repassword )
    {
        if (!CheckInput(usename, email, password , repassword))
        {
            OnrroFormat(usename, email, password , repassword);
            return;
        }

        SendRequetPlayFab(email.Trim(), password.Trim(), usename.Trim());
    }
    public void SendRequetPlayFab(string email, string password,string username)
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = email,
            Password = password,
            RequireBothUsernameAndEmail = false
            
        };
        PlayFabClientAPI.RegisterPlayFabUser(request,OnSuccess,Onerror);
    }
    private void Onerror(PlayFabError result)
    {
           AcionRegisFail?.Invoke("Lỗi ! vui lòng thử lại");    
    }
    private void OnrroFormat(string usename, string email, string password,string repassword)
    {
        AcionRegisFail.Invoke(ShowMessErro(usename,  email, password , repassword));   
    }
    private void OnSuccess(RegisterPlayFabUserResult obj)
    {
        ActionRegisSuccess?.Invoke();
    }
    public bool CheckInput(string usename, string email, string password,string repassword)
    {  
        string regex = "^[a-zA-Z0-9]{6,10}$";
        string regexPattern = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
        if (!Regex.IsMatch(email, regexPattern)) return false;
        if (!Regex.IsMatch(usename, regex)) return false;
        if (!repassword.Equals(password)) return false;
        return true;
    }
    public string ShowMessErro(string usename, string email, string password,string repassword)
    {
        string regexPattern = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
        string regex = "^[a-zA-Z0-9]{6,10}$";
        if (!Regex.IsMatch(usename, regex)) return "Tên user phải dài 6-12 ký tự và không có ký tự đặc biệt";
        if (!Regex.IsMatch(email, regexPattern)) return "Sai Dinh Dang Email";
        if (!repassword.Equals(password)) return "Hai Mat Khau Khong Giong Nhau";
        return "";
    }
    
}
