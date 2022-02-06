using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 
    float movement;
    
    Player playerScript;
    
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType<Player>().GetComponent<Player>(); ;

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement = Input.GetAxis("Horizontal");
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        rb.MovePosition(new Vector2(rb.position.x + (movement * playerScript.speed * Time.deltaTime), rb.position.y));
    }
    
    

}
