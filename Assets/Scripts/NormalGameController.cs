using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalGameController : MonoBehaviour
{
    public PlayerSpawn playerSpawn;
    private Score score;

    public void StartGame()
    {
        playerSpawn.SpawnPlayer();
    }
}
