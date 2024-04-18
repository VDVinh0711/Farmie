using System;
using System.Collections.Generic;
using PlayFab;
using PlayFab.AuthenticationModels;
using PlayFab.ClientModels;
using UnityEngine;

public static class PlayFabData 
{
    
    public static void PushDataIntoPlayFab(string  namepath , string datas )
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
    private static void OnSucessPushData(PlayFabError result)
    {
        Debug.Log("Push data sucess");
    }
    private static  void OnErrorPushData(UpdateUserDataResult result)
    {
        Debug.Log("Push Error" + result);
    }
    //GetData
    public static void GetDataOnPlayFab(Action<GetUserDataResult> getdataRecive)
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), getdataRecive , OnErrorFailGetData);
    }
    private static void OnErrorFailGetData(PlayFabError result)
    {
        Debug.Log("On getData Error");
    }
    
    public static bool CheckData(string keyData)
    {
        bool resulttesst = false;
        GetDataOnPlayFab((result =>
                {
                    if (result.Data.ContainsKey("PartPlayer"))
                    {
                        resulttesst = true;
                    }
                }
                ));
        return resulttesst;
    }
    
    
   
}
