using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{

    public int worth, minWorth;
    


    GameObject player, pointCollector, gameController;

    CircleCollider2D cc;
    PointEffector2D pe;
    Rigidbody2D rig, preRig;

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

                    ConvertToMagnet();

                }

                break;


        }

  
    }

    void ConvertToMagnet()
    {

        gameObject.layer = 6;





        GameObject prefabChild = new GameObject();

        prefabChild.name = "magnet Collider";
        prefabChild.layer = 6;

        prefabChild.transform.parent = gameObject.transform;

        cc = prefabChild.AddComponent(typeof(CircleCollider2D)) as CircleCollider2D;

        cc.name = "GravityRadius";
        cc.radius = 4;
        cc.isTrigger = true;
        cc.usedByEffector = true;


        pe = prefabChild.AddComponent(typeof(PointEffector2D)) as PointEffector2D;

        pe.forceMode = EffectorForceMode2D.InverseSquared;
        pe.useColliderMask = true;
        pe.colliderMask = LayerMask.GetMask("ObjectsSM");

        preRig = prefabChild.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        preRig.gravityScale = 0;
        preRig.bodyType = RigidbodyType2D.Kinematic;

        prefabChild.transform.position = gameObject.transform.position;


        rig.bodyType = RigidbodyType2D.Kinematic;
        rig.isKinematic = true;
        rig.velocity = Vector2.zero;
        rig.freezeRotation = true;


        gameController.GetComponent<GameControllerScript>().addMagnet(gameObject);

        isMagnet = true;
    }


    public int GetMinWorth()
    {

        return minWorth;

    }

}
