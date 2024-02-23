using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class RegisterAccount 
{


    public RegisterAccount()
    {
        
    }
    public void Register(string email, string passwork)
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = email,
            Password = passwork,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnSuccess, Onerror);
        
    }
    private void Onerror(PlayFabError result)
    {
        Debug.Log("Register fail " + result.ToString());
       
    }

    private void OnSuccess(RegisterPlayFabUserResult obj)
    {
       Debug.Log("register Success");
    }
}
