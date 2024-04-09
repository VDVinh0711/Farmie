using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginCotroller : MonoBehaviour
{
    [SerializeField] private UI_Login _uiLogin;
    public Action ActionloginSuccess;
    public Action<string> AcionloginFail;
    
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
        ActionloginSuccess?.Invoke();
       // SceneManager.LoadScene("CharacterCreator");
    }
    private void OnError(PlayFabError result)
    {
        AcionloginFail?.Invoke(result.ToString());
    }
    
    



 
    
}
