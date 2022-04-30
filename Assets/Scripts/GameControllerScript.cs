using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{

    public GameObject player;
    GameObject pointCollector;
    public GameObject[] objectPrefabs;

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

            i.GetComponent<PointEffector2D>().colliderMask = nMask;

        }

        Debug.Log(nMask);

    }

    LayerMask GetLayerMask()
    {

        int points = pointCollector.GetComponent<PointCollector>().GetPoints();

        if (points < 5)
        {

            return LayerMask.GetMask("ObjectsSM");

        }
        else if (points < 10)
        {

            return LayerMask.GetMask("ObjectsSM","ObjectsM");

        }
        else if (points < 25)
        {

            return LayerMask.GetMask("ObjectsSM", "ObjectsM", "ObjectsL");

        }
        else 
        {

            return LayerMask.GetMask("ObjectsSM", "ObjectsM", "ObjectsL", "ObjectsXL");

        }

    }

}
