using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject page1;
    public GameObject page2;
    // Start is called before the first frame update
    void Start()
    {

        audioSource = FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame

 
    public void GoToScene(string sceneName)     { SceneManager.LoadScene(sceneName); }

    public void ExitGame()      { Application.Quit(); Debug.Log("QUIT");}

    public void SetVolume(float volume)     { audioSource.volume = volume; }

    public void LoadNextPage(int pageNum)
    {
        if (pageNum==2)
        {
            page1.SetActive(false);
            page2.SetActive(true);
        }
        else if (pageNum==1)
        {
            page2.SetActive(false);
            page1.SetActive(true);
        }
    }

    public void SetDifficulty(int difficultyIndex)
    {
        if (difficultyIndex == 1)
            PlayerPrefs.SetString("Difficulty", "Easy");
        else if (difficultyIndex == 0)
            PlayerPrefs.SetString("Difficulty", "Normal");
        else if (difficultyIndex == 2)
            PlayerPrefs.SetString("Difficulty", "Hard");
        Debug.Log(PlayerPrefs.GetString("Difficulty", "Normal"));
    }

    public void OpenInstagram()
    {
        Application.OpenURL("https://www.instagram.com/zuryansh01/");
    }
}
