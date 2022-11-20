using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public int score;
    public Text txt;

    private bool end;
    private GameController gameController;
    private RankingRepository rankingRepository;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        gameController = GetComponent<GameController>();
        rankingRepository = GetComponent<RankingRepository>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!end) {
            txt.text = score.ToString();
            if(gameController.endAt != null) {
                end = true;
                SaveScore();
            }
        }
    }

    public void Increment()
    {
        score++;
    }

    private void SaveScore()
    {
        rankingRepository.SaveRanking(score);
    }
}
