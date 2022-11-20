using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTModels;
public class RankingPanelController : MonoBehaviour
{
    public TMPro.TextMeshProUGUI[] top1UI;
    public TMPro.TextMeshProUGUI[] top2UI;
    public TMPro.TextMeshProUGUI[] top3UI;
    private Ranking[] ranking;
    public MenuController menuController;
    // Update is called once per frame
    void Update()
    {
        if (ranking != menuController.ranking)
        {
            ranking = menuController.ranking;
        }
        if(ranking.Length > 0) {
            top1UI[0].text = "Score: "+ranking[0].score;
            top1UI[1].text = ranking[0].user.name;

            top2UI[0].text = "Score: "+ranking[1].score;
            top2UI[1].text = ranking[1].user.name;

            top3UI[0].text = "Score: "+ranking[2].score;
            top3UI[1].text = ranking[2].user.name;
        }
    }
}
