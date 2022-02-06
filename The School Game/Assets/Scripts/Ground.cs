using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    Player playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType<Player>().GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Trash")
        {
            playerScript.lives -= 1;
        }
    }
}
