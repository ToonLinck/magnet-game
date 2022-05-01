using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public TextMeshProUGUI score;
    public GameObject points;
    

    // Update is called once per frame
    void Update()
    {
        int pointnumber = points.GetComponent<PointCollector>().GetPoints();
        if(pointnumber >= 250)
        {
            pointnumber = 250;
        }
        score.text = pointnumber + "/250";
    }
}
