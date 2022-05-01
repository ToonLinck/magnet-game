using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    public float timeElapsed = 0f;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    public GameObject points;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }
    void Update()
    {
        int numberofpoints = points.GetComponent<PointCollector>().GetPoints();
        if (numberofpoints <= 250)
        {
            if (timerIsRunning)
            {
                timeElapsed += Time.deltaTime;
                DisplayTime(timeElapsed);
            }
        }
        else
        {
            timerIsRunning = false;
            PlayerPrefs.SetFloat("Highscore_raw",timeElapsed);
            PlayerPrefs.Save();
            points.GetComponent<PointCollector>().FinishGame();
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = (timeToDisplay % 1) * 1000;
        timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }
}