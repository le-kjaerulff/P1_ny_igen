using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(3);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
    public void playNextScene()
    {
        SceneManager.LoadScene(1);
    }

    public void playPreviousScene()
    {
        SceneManager.LoadScene(0);
    }

    public void playThirdScene()

    {
        SceneManager.LoadScene(2);
    }

    public void PlayThreeScenesBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

}
