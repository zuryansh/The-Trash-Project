using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    Player playerScript;

    private void Start()
    {
        playerScript = FindObjectOfType<Player>().GetComponent<Player>();
        healthSlider.maxValue = playerScript.lives;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = playerScript.lives;
    }
}
