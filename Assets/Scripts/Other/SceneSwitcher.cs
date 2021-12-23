using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    string currentScene;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScene == "MainMenu")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                LoadIntro();
            }
        }
    }

   public void LoadLevel()
    {
        SceneManager.LoadScene("Level");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadIntro()
    {
        SceneManager.LoadScene("Intro");
    }

    public void LoadOutro()
    {
        SceneManager.LoadScene("Outro");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
