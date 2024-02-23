using System;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class LoginSystem
{
    private Action loginSuccess;
    private Action<string> loginFail;
    public LoginSystem(Action loginSuccess , Action<string> loginFail)
    {
        this.loginFail = loginFail;
        this.loginSuccess = loginSuccess;
    }
    public void Login(string emailUser , string passwork)
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailUser,
            Password = passwork
        };
        PlayFabClientAPI.LoginWithEmailAddress(request,OnSuccess,OnError);
    }

    private void OnSuccess(LoginResult result)
    {
        loginSuccess?.Invoke();
    }

    private void OnError(PlayFabError result)
    {
        loginFail?.Invoke(result.ToString());
    }
}
