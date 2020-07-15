using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    // Start is called before the first frame update
   

    // Update is called once per frame
    public void PlayGame()
    {
        SceneManager.LoadScene("Scenes/Levels/Runner");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
