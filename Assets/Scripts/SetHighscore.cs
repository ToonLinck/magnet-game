using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SetHighscore : MonoBehaviour
{

    public float highscore;
    public float oldHighscore;
    public TextMeshProUGUI highscore_readable;

    
    public void Setter()
    {
        oldHighscore = PlayerPrefs.GetFloat("highscoreOld");
        if (PlayerPrefs.GetFloat("highscoreOld") == 0)
        {
            highscore_readable.text = "--:--:---";
        }

        if((0 < PlayerPrefs.GetFloat("Highscore_raw")) && (PlayerPrefs.GetFloat("Highscore_raw") <= PlayerPrefs.GetFloat("highscoreOld")))
        {
            highscore = PlayerPrefs.GetFloat("Highscore_raw");
            DisplayTime(highscore);
        }
        if((0 < PlayerPrefs.GetFloat("Highscore_raw")) && (PlayerPrefs.GetFloat("Highscore_raw") > PlayerPrefs.GetFloat("highscoreOld")))
        {
            DisplayTime(oldHighscore);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = (timeToDisplay % 1) * 1000;
        highscore_readable.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }

    public void ResetOldHighscore()
    {
        PlayerPrefs.SetFloat("highscoreOld", 0);
        PlayerPrefs.Save();
        Setter();
    }
}
