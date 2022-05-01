using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetHighscore : MonoBehaviour
{

    public float Highscore;
    public TextMeshProUGUI Highscore_readable;

    void Update()
    {
        Setter();
    }
    public void Setter()
    {
        Highscore = PlayerPrefs.GetFloat("Highscore_raw");
        DisplayTime(Highscore);
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = (timeToDisplay % 1) * 1000;
        Highscore_readable.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }
}
