using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HudController : MonoBehaviour
{
    public Text ScoreText;
    public Image Ability1Image;
    public Image Ability2Image;
    public Image AbilityFlashImage;
    public Image AbilityPotionImage;
    public TMPro.TextMeshProUGUI AbilityPotionText;
    public Image LifeBarImage;

    public GameObject GameHud;
    public GameObject OptionsPanel;
    public GameObject ConfigPanel;
    public GameObject EndPanel;
    public Slider HudSizeSlider;
    public TMPro.TextMeshProUGUI EndScoreText;
    private GameController gameController;
    private Score score;

    private void Start() {
        GameHud.SetActive(true);
        OptionsPanel.SetActive(false);
        ConfigPanel.SetActive(false);
        EndPanel.SetActive(false);
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        score = GameObject.FindGameObjectWithTag("GameController").GetComponent<Score>();
    }

    private void Update() {
        VerifyPause();
        VerifyEnd();
    }

    private void VerifyPause() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void VerifyEnd()
    {
        if(gameController.endAt != null) {
            EndScoreText.text = "Score: " + score.score;
            EndPanel.SetActive(true);
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        OptionsPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        OptionsPanel.SetActive(false);
        ConfigPanel.SetActive(false);
        EndPanel.SetActive(false);
    }

    public void BackToMenu()
    {
        ResumeGame();
        SceneLoader.Instance.LoadSceneAsync("MenuScene");
    }

    public void OpenConfigPanel()
    {
        ConfigPanel.SetActive(true);
    }

    public void CloseConfigPanel()
    {
        ConfigPanel.SetActive(false);
    }

    public void SaveSettings()
    {
        GetComponent<CanvasScaler>().scaleFactor = 1 + HudSizeSlider.value;
    }
}
