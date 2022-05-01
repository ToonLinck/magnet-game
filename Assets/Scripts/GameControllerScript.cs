using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{

    public GameObject player;
    GameObject pointCollector;

    GameObject[] magnets;


    // Start is called before the first frame update
    void Start()
    {
        pointCollector = GameObject.Find("PointController");

        magnets = new GameObject[1];
        magnets[0] = player;

        UpdateLayerMask();

    }

    // Update is called once per frame
    void Update()
    {
        
    }









    public void addMagnet(GameObject nMagnet)
    {

        GameObject[] nMagnets = new GameObject[magnets.Length + 1];

        int i = 0;

        foreach (GameObject mag in magnets) 
        {

            nMagnets[i] = mag;
            i++;

        }

        nMagnets[nMagnets.Length - 1] = nMagnet;

        magnets = nMagnets;

        UpdateLayerMask();
    }

    void UpdateLayerMask()
    {
        LayerMask nMask = GetLayerMask();

        foreach (GameObject i in magnets)
        {

            if(i == player) { i.GetComponent<PointEffector2D>().colliderMask = nMask; return; }

            i.transform.GetChild(0).gameObject.GetComponent<PointEffector2D>().colliderMask = nMask;

        }


    }

    LayerMask GetLayerMask()
    {

        int[] reqs = pointCollector.GetComponent<PointCollector>().GetPointReqs();

        int points = pointCollector.GetComponent<PointCollector>().GetPoints();

        if (points < reqs[0])
        {

            return LayerMask.GetMask("ObjectsSM");

        }
        else if (points < reqs[1])
        {

            return LayerMask.GetMask("ObjectsSM","ObjectsM");

        }
        else if (points < reqs[2])
        {

            return LayerMask.GetMask("ObjectsSM", "ObjectsM", "ObjectsL");

        }
        else 
        {

            return LayerMask.GetMask("ObjectsSM", "ObjectsM", "ObjectsL", "ObjectsXL");

        }

    }


    public void DeleteSMCollider()
    {


        foreach (GameObject magnet in magnets)
        {

            if (magnet == player) {Debug.Log("Object was player"); return; }

            if (magnet.GetComponent<ObjectMovement>().GetMinWorth() == 0)
            {

                Destroy(magnet.transform.GetChild(0).GetComponent<CircleCollider2D>());

            }

        } 

    }


}
