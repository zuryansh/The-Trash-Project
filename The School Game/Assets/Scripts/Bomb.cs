using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    
    public bool isRecyclable;
    public float yOffset = 1f;
    public float xOffset = 0.5f;
    public float fallSpeed = 10f;
    float randomX;
    float screenBottom;
    Rigidbody2D rb;




    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        screenBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).y;
        xOffset = Screen.width / 10;

        RandomizePosition();
        if (FindObjectOfType<Trash>())
        {
            if (transform.position.x - FindObjectOfType<Trash>().transform.position.x <= 0.7)
            {
                
                rb.MovePosition(new Vector2(transform.position.x + 3, transform.position.y+3));
            }

        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(new Vector2(transform.position.x, (transform.position.y - fallSpeed * Time.deltaTime)));
        //if (FindObjectOfType<Trash>())
        //{
        //    if (transform.position.x - FindObjectOfType<Trash>().transform.position.x<=0.7)
        //    {
                
        //        rb.MovePosition(new Vector2(transform.position.x+2, transform.position.y));
        //    }

        //}

        if (transform.position.y < screenBottom - 1)
        {
            Destroy(gameObject);
        }
    }


    void RandomizePosition()
        {
            randomX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(+xOffset, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - xOffset, 0)).x);
        
            float y = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;

            transform.position = new Vector2(randomX, y - yOffset);
        }



}
