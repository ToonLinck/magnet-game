using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit_Game : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("m"))
        {
            SceneManager.LoadScene("Menu");
            Cursor.visible = true;
        }
    }
}
