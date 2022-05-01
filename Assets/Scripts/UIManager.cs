using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Canvas TutorialMenu;
    public Canvas HighscoresMenu;
    public Canvas CreditsMenu;
    public bool a = false;
    public bool b = false;
    public bool c = false;
    public void StartGame() //Starts the game
    {
        SceneManager.LoadScene("Main");
    }
    public void QuitGame() //Quits the game
    {
        Application.Quit();
    }

    public void TutorialPopup() //Tutorial Page
    {
        if (a == false)
        {
            a = true;
            TutorialMenu.enabled = true;
        }
        else
        {
            a = false;
            TutorialMenu.enabled = false;
        }
    }

    public void HighscoresPopup() //Highscores Page
    {
        if (b == false)
        {
            b = true;
            HighscoresMenu.enabled = true;
        }
        else
        {
            b = false;
            HighscoresMenu.enabled = false;
        }
    }

    public void CreditsPopup() //Credits Page
    {
        if (c == false)
        {
            c = true;
            CreditsMenu.enabled = true;
        }
        else
        {
            c = false;
            CreditsMenu.enabled = false;
        }
    }
}

