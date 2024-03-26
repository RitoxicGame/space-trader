using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;
    [SerializeField] GameObject pausemenu;

    private void Start()
    {
        GameIsPaused = false;
        pausemenu.SetActive(false);
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Toggling pause menu");
            TogglePause();
        }
    }

    /*public void Resume() 
    {
        pausemenu.SetActive(false);
        GameIsPaused = false;
    }
    void Pause() 
    {
        pausemenu.SetActive(true);
        GameIsPaused = true;
    }*/

    public void TogglePause()
    {
        GameIsPaused = !GameIsPaused;
        pausemenu.SetActive(GameIsPaused);
    }
    public void BacktoMain() 
    {
        GameIsPaused = false;
        pausemenu.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame() 
    {
        Application.Quit();
    }


}
