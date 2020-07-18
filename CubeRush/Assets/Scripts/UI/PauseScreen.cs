using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public Animator transition;
    public float transitionTime = 1f;
    public LevelComplete quitGame;
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("QUITING GAME");
        SceneManager.LoadScene("Scenes/Menu");
        Time.timeScale = 1f;

    }





}
