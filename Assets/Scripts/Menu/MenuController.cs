using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTModels;
public class MenuController : MonoBehaviour
{
    public User user;
    public Ranking[] ranking;
    private UsersRepository usersRepository;
    private RankingRepository rankingRepository;
    public Sprite[] RankIcons;

/*     public Dictionary<string, KeyCode> keys;
    public GameObject[] keyButtons; */

    private void Start() {
        usersRepository = GetComponent<UsersRepository>();
        rankingRepository = GetComponent<RankingRepository>();
        LoadUser();
        LoadRanking();

/*         keys.Add("Ability1Key", (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Ability1Key", "Q")));
        keys.Add("Ability2Key", (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Ability1Key", "E")));
        keys.Add("FlashKey", (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Ability1Key", "F")));
        keys.Add("PotionKey", (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Ability1Key", "1"))); */
    }

    public void StartNormalGame()
    {
        SceneLoader.Instance.LoadSceneAsync("GameScene");
    }

    public void LoadUser()
    {
        usersRepository.GetUserInfo()
        .Then(res => {
            user = res; 
        });
    }

    public void LoadRanking()
    {
        rankingRepository.GetRaking()
        .Then(res =>
        {
            ranking = res;
        });
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void GoToCharacterSelection()
    {
        SceneLoader.Instance.LoadSceneAsync("CharacterSelectScene");
    }
}
