using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnManager : MonoBehaviour
{
    public int maxZombies;
    public GameObject[] spawnpoints;
    public float spawnTimer;
    private float lastSpawnTimer;
    public GameObject zombie;
    int zombieCount;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTimer = 0;
        zombieCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        lastSpawnTimer += Time.deltaTime;
        
        if (lastSpawnTimer >= spawnTimer)
        {
            spawnZombie();
        }
    }

    public void spawnZombie()
    {
        if (zombieCount < maxZombies)
        {
            System.Random r = new System.Random();
            int index = r.Next(0, spawnpoints.Length);
            GameObject newZombie = Instantiate(zombie);
            newZombie.transform.position = spawnpoints[index].transform.position;
            newZombie.SetActive(true);
            lastSpawnTimer = 0;
            zombieCount++;
        }

    }
}
