using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bombObj;
    public float spawnTime;
    public float initialSpawnTime;
    public int minSpawnTime;
    public int maxSpawnTime;
    public bool isSpawning = true;

    void Start()
    {
        isSpawning = true;
        Invoke("SpawnObject", initialSpawnTime); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObject()
    {
        if (isSpawning)
        {
            Instantiate(bombObj);
        }
        CancelInvoke();
        Invoke("SpawnObject", Random.Range(minSpawnTime, maxSpawnTime)); 
    }
}
