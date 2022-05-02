using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    
    public float highscore;
    public float oldHighscore;
    public TextMeshProUGUI highscore_readable;
    public Canvas newHighscore;

    public void Start()
    {
        ShowHighscore();
    }
    public void TryAgain()
    {
        SceneManager.LoadScene("Main");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ShowHighscore()
    {
        highscore = PlayerPrefs.GetFloat("Highscore_raw");
        DisplayTime(highscore);
        if ((0 < PlayerPrefs.GetFloat("Highscore_raw")) && (PlayerPrefs.GetFloat("Highscore_raw") <= PlayerPrefs.GetFloat("highscoreOld")))
        {
            newHighscore.enabled = true;
        }
        else
        {
            newHighscore.enabled = false;
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = (timeToDisplay % 1) * 1000;
        highscore_readable.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }
}
