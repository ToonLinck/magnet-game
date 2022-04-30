using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{

    public int worth, minWorth;
    


    GameObject player, pointCollector, gameController;

    CircleCollider2D cc;
    Rigidbody2D rig;

    bool isMagnet = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        pointCollector = GameObject.Find("PointController");
        gameController = GameObject.Find("GameController");


        rig = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        switch (collision.gameObject.layer)
        {

            case 6:

                if (!isMagnet && pointCollector.GetComponent<PointCollector>().GetPoints() >= minWorth)
                {

                    transform.parent = player.transform;

                    pointCollector.GetComponent<PointCollector>().AddPoints(worth);

                    Debug.Log(pointCollector.GetComponent<PointCollector>().GetPoints());

                    ConvertToMagnet();

                }

                break;


        }

  
    }

    void ConvertToMagnet()
    {

        gameObject.layer = 6;

        cc = gameObject.AddComponent(typeof(CircleCollider2D)) as CircleCollider2D;

        cc.radius = 4;
        cc.isTrigger = true;
        cc.usedByEffector = true;


        rig.bodyType = RigidbodyType2D.Kinematic;


        gameController.GetComponent<GameControllerScript>().addMagnet(gameObject);

        isMagnet = true;
    }


}
