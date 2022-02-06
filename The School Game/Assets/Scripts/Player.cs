using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Sprite canRecyceleSprite;
    [SerializeField] Sprite cantRecyceleSprite;
    public int lives=3;
    public float speed = 10;
    public bool CanRecycle;
    public bool hasDied;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        ShouldChangeType();
    }

    void ShouldChangeType()
    {
        if (CanRecycle == true) { spriteRenderer.sprite = canRecyceleSprite; }else if (CanRecycle == false) { spriteRenderer.sprite = cantRecyceleSprite; }
    }

  
}
