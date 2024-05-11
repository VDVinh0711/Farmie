using System;
using System.Collections.Generic;
using PlayFab;
using PlayFab.AuthenticationModels;
using PlayFab.ClientModels;
using UnityEngine;

public static class PlayFabData
{



    public static List<string> keys = new List<string>();
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

    public static bool CheckIsKey(string namekey)
    {
        if (keys.Contains(namekey)) return true;
        return false;
    }


    public static void GetKeyData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), GetList , OnErrorFailGetData);
    }

    private static void GetList(GetUserDataResult data)
    {
        keys = new List<string>();
        foreach (var o in data.Data)
        {
            Debug.Log(o.Key);
            keys.Add(o.Key);
        }
    }
    
    
   
}
