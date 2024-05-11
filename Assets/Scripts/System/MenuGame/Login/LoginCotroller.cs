using System;

using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;


public class LoginCotroller : MonoBehaviour
{
    [SerializeField] private LoadSceneHelper _loadScene;
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
        PlayFabData.GetKeyData();
        ActionloginSuccess?.Invoke();
      _loadScene.StarLoadSceneCouroutine("CharacterCreator");
        
    }
    private void OnError(PlayFabError result)
    {
        AcionloginFail?.Invoke("Đăng nhập thất bại");
    }

}

