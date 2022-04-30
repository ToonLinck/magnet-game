using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollector : MonoBehaviour
{

    int points;



    public void FinishGame()
    {



    }



    public int GetPoints()
    {

        return points;

    }
    public void AddPoints(int nPoints)
    {

        points += nPoints;

    }

}
