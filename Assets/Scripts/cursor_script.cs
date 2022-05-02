using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor_script : MonoBehaviour
{

    public GameObject player;

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(cursorPos.x, cursorPos.y, -5) ;

        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q,1);
    }
}
