using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Authentication;
using Unity.Services.Core;
using System.Threading.Tasks;


public class AuthManager : MonoBehaviour
{
    private string _playerId;
    async void Start()
    {
        await UnityServices.InitializeAsync();
        SingIn();
    }

    async void SingIn()
    {
        await signAno();
    }


    async Task signAno()
    {
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            _playerId = AuthenticationService.Instance.PlayerId;
            PlayerPrefs.SetString("Pid",_playerId);
            Debug.Log(AuthenticationService.Instance.PlayerId);
        }
        catch (AuthenticationException ex)
        {
            Debug.Log(ex);
        }

    }

}
