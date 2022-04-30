using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{



    GameObject player;

    CircleCollider2D cc;
    Rigidbody2D rig;

    bool isMagnet = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

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

                if (!isMagnet)
                {

                    transform.parent = player.transform;

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

        isMagnet = true;
    }


}
