using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public static bool GamePaused = false; //Pause State
    [SerializeField] private string MenuName; //Scene to load

    public GameObject PauseMenu;  //The Menu UI Window

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }
    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        GamePaused = true;
    }

    public void MainMenu()
    {
        GamePaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(MenuName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
