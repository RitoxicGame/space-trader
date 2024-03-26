using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pausemenu;
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameIsPaused)
            {
                Pause();
            }
            else 
            {
                Resume();
            }
        }
    }

    public void Resume() 
    {
        pausemenu.SetActive(false);
        GameIsPaused = false;
    }
    void Pause() 
    {
        pausemenu.SetActive(true);
        GameIsPaused = true;
    }

    public void BacktoMain() 
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame() 
    {
        Application.Quit();
    }


}
