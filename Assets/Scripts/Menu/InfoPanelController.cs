using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MTModels;
public class InfoPanelController : MonoBehaviour
{
    public TMPro.TextMeshProUGUI nicknameText;
    public TMPro.TextMeshProUGUI scoreText;
    public Image rankIcon;

    private User userInfo;
    public MenuController menuController;

    // Update is called once per frame
    void Update()
    {
        if(userInfo != menuController.user)
        {
            userInfo = menuController.user;
        }
        nicknameText.text = userInfo.name;
        scoreText.text = "Rank: "+userInfo.rank+" Score: "+userInfo.bestScore;
        var iconIndex = userInfo.rank >= 4 ? 0 : userInfo.rank;
        rankIcon.sprite = menuController.RankIcons[iconIndex];
    }
}
