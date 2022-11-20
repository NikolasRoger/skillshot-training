using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Proyecto26;
using AuthDTO;

public class AuthRepository : MonoBehaviour
{
    private readonly string basePath = "https://mtapi.sdeincubator.com.br";
    private RequestHelper currentRequest;

    public RSG.IPromise<LoginResponse> Login(LoginRequest data)
    {
        currentRequest = new RequestHelper
        {
            Uri = basePath + "/auth",
            Body = data,
            EnableDebug = true
        };
        return RestClient.Post<LoginResponse>(currentRequest);
    }
}
