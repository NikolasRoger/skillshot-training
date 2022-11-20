using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject[] skins;

    public string selectedSkin = "Souta";

    public void SpawnPlayer()
    {
        if (PlayerPrefs.HasKey("character"))
        {
            selectedSkin = PlayerPrefs.GetString("character");
        }
        foreach(GameObject skin in skins)
        {
            if(skin.name.ToLower() == selectedSkin.ToLower()) {
                Instantiate(skin, transform.position, transform.rotation);
            }
        }
    }
}
