using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject[] objectPrefabs;

    Vector2 spawnCenter;

    public int spawnRadius, spawnAmount;

    // Start is called before the first frame update
    void Start()
    {
        spawnCenter = new Vector2(0, 0);

        SpawnObjects(spawnAmount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isInsideSpawnradius(Vector2 point)
    {
        return Mathf.Sqrt((point.x*point.x) + (point.y*point.y)) <= spawnRadius;
    }


    GameObject[] SpawnObjects (int amount)
    {

        GameObject[] spawns = new GameObject[amount + 1];

        for (int i = 0; i < amount; i++)
        {
            Vector3 point = new Vector3(Random.Range(-spawnRadius, spawnRadius), Random.Range(-spawnRadius, spawnRadius),0);

            while(!isInsideSpawnradius(point))
            {

                point = new Vector2(Random.Range(-spawnRadius, spawnRadius), Random.Range(-spawnRadius, spawnRadius));

            }

            GameObject prefab = Instantiate(objectPrefabs[Random.Range(0, objectPrefabs.Length)]) as GameObject;

            prefab.transform.position = point;
            prefab.GetComponent<Rigidbody2D>().rotation = Random.Range(0,359);

           // Debug.Log("instantiated Object at " + prefab.transform.position);

            spawns[i] = prefab;

        }



        return spawns;

    }

}
