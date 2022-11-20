using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Proyecto26;
using MTModels;
using UsersDTO;

public class UsersRepository : MonoBehaviour
{

    private readonly string basePath = "https://mtapi.sdeincubator.com.br";
    private RequestHelper currentRequest;

    public RSG.IPromise<User> CreateUser(CreateUserRequest data) {
        currentRequest = new RequestHelper
        {
            Uri = basePath + "/users",
            Body = data
        };
        return RestClient.Post<User>(currentRequest);
    }

    public RSG.IPromise<User> GetUserInfo() {
        RestClient.DefaultRequestHeaders["Authorization"] = "Bearer "+PlayerPrefs.GetString("token");

        currentRequest = new RequestHelper
        {
            Uri = basePath + "/info"
        };
        return RestClient.Get<User>(currentRequest);
    }
}
