using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    //Implementation partly "borrowed" from ApplyToTheIndustrySim's TitleScreenBehavior

    [SerializeField] GameObject title;
    [SerializeField] GameObject settings;
    // Start is called before the first frame update
    void Start()
    {
        //button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToggleSettingsMenu()
    {
        title.SetActive(!title.activeInHierarchy);
        settings.SetActive(!settings.activeInHierarchy);
    }
}
