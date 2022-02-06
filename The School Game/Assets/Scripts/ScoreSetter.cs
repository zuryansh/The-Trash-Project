using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSetter : MonoBehaviour
{
    TextMeshProUGUI textBox1;
    public TextMeshProUGUI textBox2;
    public TextMeshProUGUI hiscoreTextBox1;
    public TextMeshProUGUI hiscoreTextBox2;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        textBox1 = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (score > PlayerPrefs.GetInt("Hiscore",0))
        {
            PlayerPrefs.SetInt("Hiscore",score);
        }
        textBox1.text = score.ToString();
        textBox2.text = score.ToString();
        hiscoreTextBox1.text = PlayerPrefs.GetInt("Hiscore", 0).ToString();
        hiscoreTextBox2.text = PlayerPrefs.GetInt("Hiscore", 0).ToString();
    }
}
