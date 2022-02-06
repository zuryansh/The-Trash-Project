using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
   
    public bool isRecyclable;
    public float yOffset = 1f;
    public float xOffset = 0.5f;
    public float fallSpeed=10f;
    public int rewardedScore;


    Vector3 spriteCenterPos;
    float spriteWidth;
    float randomX;
    float screenWidth;
    float screenBottom; 

        

    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;

    private void Start()
    {
        screenBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).y;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteCenterPos = spriteRenderer.bounds.center;
        screenWidth = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
        spriteWidth = spriteRenderer.bounds.extents.x;
        rb = GetComponent<Rigidbody2D>();
        xOffset = Screen.width / 10;

        RandomizePosition();
        
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(new Vector2(transform.position.x,(transform.position.y - fallSpeed*Time.deltaTime)));

        if (transform.position.y < screenBottom-1)
        {
            GameObject.Destroy(gameObject);
        }
    }


    public void RandomizePosition()
    {

         randomX =  Random.Range
        (Camera.main.ScreenToWorldPoint(new Vector2(+xOffset, 0)).x , Camera.main.ScreenToWorldPoint(new Vector2(Screen.width-xOffset, 0)).x);
        if (spriteCenterPos.x>screenWidth)
        {
            
        }

        float y = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;

        transform.position = new Vector2(randomX, y-yOffset);
    }

 
   
}
