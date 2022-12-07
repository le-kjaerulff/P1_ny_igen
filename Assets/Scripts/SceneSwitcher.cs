using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public int mainMenu = 0;
    public int tutorial = 1;
    public int options = 2;
    public int level_1 = 3;
   

    public void playGame()
    {
        SceneManager.LoadScene(level_1);
    }

    public void goToMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
    public void playTutorial()
    {
        SceneManager.LoadScene(tutorial);
    }

    public void goToOptions()

    {
        SceneManager.LoadScene(options);
    }

}


