using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Proyecto26;
using MTModels;
using RankingDTO;

public class RankingRepository : MonoBehaviour
{
    private readonly string basePath = "https://mtapi.sdeincubator.com.br";
    private RequestHelper currentRequest;

    public RSG.IPromise<Ranking[]> GetRaking()
    {
        currentRequest = new RequestHelper
        {
            Uri = basePath + "/ranking"
        };
        return RestClient.GetArray<Ranking>(currentRequest);
    }

    public void SaveRanking(int newScore)
    {
        RestClient.DefaultRequestHeaders["Authorization"] = "Bearer " + PlayerPrefs.GetString("token");

        currentRequest = new RequestHelper
        {
            Uri = basePath + "/ranking",
            Body = new SaveRankingRequest {
                score = newScore
            }
        };
        RestClient.Post<SaveRankingResponse>(currentRequest)
        .Then(res => {
            return true;
        })
        .Catch(err => {
            Debug.Log(err.Message);
            return false;
        });
    }
}
