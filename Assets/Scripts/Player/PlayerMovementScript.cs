using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{


    Rigidbody2D rig;
    public float mvtSpeed = 0.2f;

    // Start is called before the first frame update



    void Start()
    {
        FindObjectOfType<AudioManager>().Play("BG");
        rig = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            //Debug.Log("click");
            Vector2 npos = transform.position + mvtSpeed * (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
            rig.MovePosition(npos);
        }
    }

}
