using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float respawnTime;

    public GameObject[] spawnLocations;

    public GameController gameController; 
    // Start is called before the first frame update
    void Start()
    {
        respawnTime = 6f - gameController.difficulty;
        StartCoroutine(Spawn());
    }
    
    void Update()
    {
        respawnTime = 6f - gameController.difficulty;
    }

    IEnumerator Spawn()
    {
        while(gameController.startedAt != null && gameController.endAt == null) {
            yield return new WaitForSeconds(respawnTime);

            Instantiate(enemyPrefab, GetNewSpawnPosition(), Quaternion.Euler(0, 0, 0));
        }
    }

    Vector3 GetNewSpawnPosition()
    {
        
        GameObject newSpawn = spawnLocations[Random.Range(0, spawnLocations.Length)]; 
        Vector3 response = newSpawn.transform.position;
        return response;
    }
}
