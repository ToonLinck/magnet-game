using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Canvas TutorialMenu;
    public Canvas HighscoresMenu;
    public Canvas CreditsMenu;
    public bool a = false;
    public bool b = false;
    public bool c = false;
    public SetHighscore reset;
    public void StartGame() //Starts the game
    {
        FindObjectOfType<AudioManager>().Play("MouseClick");

        SceneManager.LoadScene("Main");
    }
    public void QuitGame() //Quits the game
    {
        FindObjectOfType<AudioManager>().Play("MouseClick");

        Application.Quit();
    }

    public void TutorialPopup() //Tutorial Page
    {
        FindObjectOfType<AudioManager>().Play("MouseClick");

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
        FindObjectOfType<AudioManager>().Play("MouseClick");

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
            FindObjectOfType<AudioManager>().Play("MouseClick");
            c = true;
            CreditsMenu.enabled = true;
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Discord");
            c = false;
            CreditsMenu.enabled = false;
        }
    }

    public void OpenURLFont()
    {
        FindObjectOfType<AudioManager>().Play("MouseClick");

        Application.OpenURL("https://www.1001fonts.com/sf-atarian-system-font.html");
    }


    public void DeleteHighscore()
    {
        FindObjectOfType<AudioManager>().Play("MouseClick");
        PlayerPrefs.DeleteKey("Highscore_raw");
        reset.ResetOldHighscore();

    }

    public void OpenURLMusic()
    {
        FindObjectOfType<AudioManager>().Play("MouseClick");

        Application.OpenURL("https://www.newgrounds.com/audio/listen/997795l");
    }

    public void OpenURLGregor()
    {
        FindObjectOfType<AudioManager>().Play("MouseClick");

        Application.OpenURL("https://redskiesofficial.newgrounds.com");
    }

}

