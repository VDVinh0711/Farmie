using System;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayFabDataManager 
{
    public PlayFabDataManager()
    {}
    //Push data
    public void PushDataIntoPlayFab(string  namepath , string datas )
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                { namepath, datas }
            }
        };
        PlayFabClientAPI.UpdateUserData(request,OnErrorPushData,OnSucessPushData);
    }
    private void OnSucessPushData(PlayFabError result)
    {
        Debug.Log("Push data sucess");
    }
    private void OnErrorPushData(UpdateUserDataResult result)
    {
        Debug.Log("Push Error" + result);
    }
    //GetData
    public void GetDataOnPlayFab(Action<GetUserDataResult> getdataRecive)
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), getdataRecive , OnErrorFailGetData);
    }
    private void OnErrorFailGetData(PlayFabError result)
    {
        Debug.Log("On getData Error");
    }
    
    /*// Login
    public void Login(string emailUser , string passwork,Action<LoginResult> actionSucess , Action<PlayFabError> actionErro)
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailUser,
            Password = passwork
        };
        PlayFabClientAPI.LoginWithEmailAddress(request,actionSucess,actionErro);
    }*/
   
}
