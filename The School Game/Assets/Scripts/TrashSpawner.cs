using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject trashObj;
    public float spawnTime = 1f;
    public float Difficulty;
    public float startDifficulty;
    public float lowestSpawnTime = 0.5f;
    public float difficultyModifier = 0.1f;
    public float timeTillDifficultyDecrease = 30;
    public bool isSpawning = true;
    public GameObject[] trashVariants;


    // Start is called before the first frame update
    void Start()    
    {
        
        SetDifficultyMode();
        startDifficulty = Difficulty;
        isSpawning = true;
        StartCoroutine(ApplyDifficulty());
        //ApplyDifficulty();
        Invoke("SpawnObject",spawnTime); 

    }

    
    IEnumerator ApplyDifficulty()
    {
        yield return new WaitForSeconds(timeTillDifficultyDecrease);
        if (isSpawning)
        {
            if (spawnTime >lowestSpawnTime)
            {
            
                spawnTime -= Difficulty;//2-0.5=1.5-0.4=1.1
                Difficulty -= difficultyModifier;
            }
        }
        StartCoroutine(ApplyDifficulty());
    }
    

    // Update is called once per frame
    void SpawnObject()
    {
        if (isSpawning)
        {
        Instantiate(GetRandomTrashVariant());
        }
        CancelInvoke();
        Invoke("SpawnObject", spawnTime); 

    }

    GameObject GetRandomTrashVariant()
    {
        

        GameObject obj = trashVariants[Random.Range(0, trashVariants.Length)];
        return obj;
    }

    void SetDifficultyMode()
    {
        if (PlayerPrefs.GetString("Difficulty","Normal")=="Easy")
        {
            lowestSpawnTime = 1f;
            FindObjectOfType<BombSpawner>().GetComponent<BombSpawner>().enabled = false;
            FindObjectOfType<Player>().GetComponent<Player>().lives = 5;
        }
        else if (PlayerPrefs.GetString("Difficulty", "Normal") == "Normal")
        {
            lowestSpawnTime = 0.8f;
            FindObjectOfType<BombSpawner>().GetComponent<BombSpawner>().enabled = true;
            FindObjectOfType<Player>().GetComponent<Player>().lives = 3;
        }
        else if (PlayerPrefs.GetString("Difficulty", "Normal") == "Hard")
        {
            lowestSpawnTime = 0.5f;
            FindObjectOfType<BombSpawner>().GetComponent<BombSpawner>().enabled = true;
            FindObjectOfType<Player>().GetComponent<Player>().lives = 1;
        }
    }
}
