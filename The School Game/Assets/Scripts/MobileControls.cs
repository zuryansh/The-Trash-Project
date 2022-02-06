using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControls : MonoBehaviour
{
    Rigidbody2D rb;
    Player playerScript;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerScript = FindObjectOfType<Player>().GetComponent<Player>();
    }
    private void Update()

    {
        if (Input.touchCount > 0)
        {
            
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            //rb.MovePosition(touchPosition);
            touchPosition.y = rb.position.y;
            rb.position = touchPosition;
        }

        if (IsDoubleTap() || Input.GetKeyDown(KeyCode.Space))
        {
            if (playerScript.CanRecycle == false) { playerScript.CanRecycle = true; } else { playerScript.CanRecycle = false; }
            
        }

    }

    bool IsDoubleTap()
    {
        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                if (Input.GetTouch(i).tapCount == 2)
                {
                    return true;
                }

            }
        }
        return false;
    }
}
