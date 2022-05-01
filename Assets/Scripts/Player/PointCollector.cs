using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointCollector : MonoBehaviour
{

    int points;

    public GameObject gameController;

    public Camera cam;

    public int[] pointsReq;

    int currentReq, currentCamLevel;


    public void Start()
    {
        currentReq = pointsReq[0];

        currentCamLevel = 0;
    }


    public void FinishGame()
    {
        SceneManager.LoadScene("Menu");


    }



    public int GetPoints()
    {

        return points;

    }
    public void AddPoints(int nPoints)
    {

        points += nPoints;

        CheckCameraZoom();

    }

    void CheckCameraZoom()
    {

        if (points >= currentReq && currentCamLevel <= 2)
        {

            cam.orthographicSize += cam.orthographicSize * 0.1f;

            currentCamLevel++;

            if (points >= pointsReq[1]) { gameController.GetComponent<GameControllerScript>().DeleteSMCollider(); }

            currentReq = pointsReq[currentCamLevel];

        }
      
    }


    public int[] GetPointReqs()
    {

        return pointsReq;

    }

}
