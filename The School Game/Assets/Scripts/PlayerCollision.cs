using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    ScoreSetter scoreScript;
    
    Player playerScript;
    GameMangaer gameManager;
    public ParticleSystem trashParticleSystem;
    public ParticleSystem bombParticleSystem;

    private void Start()
    {
        scoreScript = FindObjectOfType<ScoreSetter>().GetComponent<ScoreSetter>();
        playerScript = gameObject.GetComponent<Player>();
        gameManager = FindObjectOfType<GameMangaer>().GetComponent<GameMangaer>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Trash")
        {
            Destroy(collision.gameObject);
            trashParticleSystem.Play();

            if (collision.GetComponent<Trash>().isRecyclable == playerScript.CanRecycle)

            { scoreScript.score += collision.GetComponent<Trash>().rewardedScore+10; ; }

            else { scoreScript.score += collision.GetComponent<Trash>().rewardedScore; }
        }
        if (collision.tag=="Bomb")
        {
            bombParticleSystem.Play();
            gameManager.KillPlayer();
        }
        
    }

    
}
