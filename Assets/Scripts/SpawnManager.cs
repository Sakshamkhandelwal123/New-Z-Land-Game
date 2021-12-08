using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float startDelay = 1;
    private float spawnInterval = 1.5f;
    public GameObject player;
    public GameObject[] zombiePrefabs;
    private float spawnRangeX = 2;
    private float spawnPosZ = 14;
    public bool gameEnded;
    void Start()
    {
        InvokeRepeating("SpawnRandomZombies", startDelay, spawnInterval);
    }
    // Update is called once per frame
    void Update()
    {
        gameEnded = GameObject.Find("Basic_Bandit").GetComponent<PlayerController>().gameOver;
    }
    void SpawnRandomZombies() {
        if(gameEnded == false) {
            Vector3 spawnPos = new Vector3(player.transform.position.x+Random.Range(spawnRangeX, 20), 0.1f, player.transform.position.z + spawnPosZ);
            // int zombieIndex = Random.Range(0, zombiePrefabs.Length);
            Instantiate(zombiePrefabs[0], spawnPos, zombiePrefabs[0].transform.rotation);
        }
    }
}
