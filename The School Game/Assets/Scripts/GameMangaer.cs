using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMangaer : MonoBehaviour
{
    public GameObject deathPanel;
    public TrashSpawner trashSpawner;
    public BombSpawner bombSpawner;
    public GameObject pauseText;
    public AudioSource audioMangaer;
    public AudioClip bgMusic;

    Player playerScript;
    ScoreSetter scoreSetter;
    TrashSpawner TrashSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
        playerScript = FindObjectOfType<Player>().GetComponent<Player>();
        scoreSetter = FindObjectOfType<ScoreSetter>().GetComponent<ScoreSetter>();
        trashSpawner = FindObjectOfType<TrashSpawner>().GetComponent<TrashSpawner>();
        audioMangaer = FindObjectOfType<AudioSource>();
        audioMangaer.clip = bgMusic;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.lives<=0 && !playerScript.hasDied)
        {
            KillPlayer();
        }
    }


    public void PauseGame()
    {
        if (Time.timeScale!=0)
        {//game not paused
            Time.timeScale = 0;
            pauseText.SetActive(true);
        }
        else if (Time.timeScale==0)
        {//game paused
            Time.timeScale = 1;
            pauseText.SetActive(false);
        }

    }



    public void RestartGame()
    {
        
        playerScript.hasDied = false;
        playerScript.lives = 3;
        playerScript.gameObject.SetActive(true);
        deathPanel.SetActive(false);

        trashSpawner.isSpawning = true;
        bombSpawner.isSpawning = true;
        scoreSetter.score = 0;
        trashSpawner.Difficulty = trashSpawner.startDifficulty;
        pauseText.SetActive(false);
        Time.timeScale = 1;
        DestroyAllTrash();
    }

    public void KillPlayer()
    {
        playerScript.gameObject.SetActive(false);
        playerScript.hasDied = true;
        deathPanel.SetActive(true);
        trashSpawner.isSpawning = false;
        bombSpawner.isSpawning = false;
    }

    void DestroyAllTrash()
    {
        
        foreach (var item in GameObject.FindGameObjectsWithTag("Trash"))
        {
            Destroy(item);
        }
    }
}
