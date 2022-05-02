using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointCollector : MonoBehaviour
{

    int points;

    public GameObject gameController, cursor;

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
        SceneManager.LoadScene("Game_over");
        Cursor.visible = true;
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

        if (points >= currentReq && currentCamLevel < 2)
        {

            cam.orthographicSize += cam.orthographicSize * 0.1f;

            cursor.transform.localScale = new Vector3(cursor.transform.localScale.x * 1.1f, cursor.transform.localScale.y * 1.1f, 1);

            currentCamLevel++;

            if (points >= pointsReq[1]) { gameController.GetComponent<GameControllerScript>().DeleteSMCollider(); }

            if (currentCamLevel <= 2) { currentReq = pointsReq[currentCamLevel]; }
            


        }
      
    }


    public int[] GetPointReqs()
    {

        return pointsReq;

    }

}
