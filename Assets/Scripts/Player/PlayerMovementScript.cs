using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    Rigidbody2D rig;
    float mvtSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {


            rig.velocity = transform.up * mvtSpeed * Time.deltaTime;


        }
    
    }   
}
