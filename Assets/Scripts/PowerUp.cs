using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    private float startDelay = 5;
    private float spawnInterval = 50.0f;
    private float spawnRangeX = 2;
    private float spawnPosZ = 14;
    public GameObject player;
    public GameObject[] powerUpPrefabs;
    public bool gameEnded;
    void Start()
    {
        InvokeRepeating("SpawnRandomPower", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        gameEnded = GameObject.Find("Basic_Bandit").GetComponent<PlayerController>().gameOver;
        if(gameEnded == true) {
            Destroy(gameObject);
        }
    }
    void SpawnRandomPower() {
        if(gameEnded == false) {
            Vector3 spawnPos = new Vector3(player.transform.position.x+Random.Range(spawnRangeX, 20), -3.65f, player.transform.position.z + spawnPosZ);
        // int zombieIndex = Random.Range(0, zombiePrefabs.Length);
            Instantiate(powerUpPrefabs[0], spawnPos, powerUpPrefabs[0].transform.rotation);
        }
    }
}
