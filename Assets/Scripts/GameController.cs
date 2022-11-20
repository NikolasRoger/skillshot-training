using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public enum GameType { NORMAl, RANKED };
    public Time startedAt;
    public Time endAt;
    public float time;
    public Score score;

    public NormalGameController normalGameController;

    public float difficulty;

    void Start()
    {
        difficulty = 1;
        startedAt = new Time();
        
        score = GetComponent<Score>();
        normalGameController = GetComponent<NormalGameController>();

        normalGameController.StartGame();
    }

    void Update()
    {
        VerifyDifficulty();
    }

    void VerifyDifficulty()
    {
        if (score.score >= 5 && difficulty == 1)
        {
            difficulty = 2;
        }
        else if (score.score >= 10 && difficulty == 2)
        {
            difficulty = 3;
        }
        else if (score.score >= 20 && difficulty == 3)
        {
            difficulty = 4;
        }
        else if (score.score >= 30 && difficulty == 4)
        {
            difficulty = 5;
        }
    }

    public void EndGame()
    {
        Time.timeScale = 1;
        SceneLoader.Instance.LoadSceneAsync("GameScene");
    }
}
