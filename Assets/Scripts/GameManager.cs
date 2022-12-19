using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int PlayerScore = 0; 
    public int QuestionNumberInSet;         // HUSK AT ÆNDRE TILBAGE TIL PRIVATE!!!
    public bool waitingForUserAnswer;       
    public int questionNumberInSet
    {
        get
        {
            return QuestionNumberInSet;
        }
        set
        {
            QuestionNumberInSet = value;
        }
    }
    public int playerScore
    {
        get { return PlayerScore;
        }
        set
        {
            PlayerScore = value;
        }
    }
    public Dictionary<int, string> questionTypeForScene = new Dictionary<int, string>()
    {
        {3, "noun" },
        {4, "preposition"},
        {5, "preposition"},
    };
    public int currentScene;
    private void Awake()
    {
       DontDestroyOnLoad(this.gameObject);
       currentScene = SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {
        LevelProgressTracker();
    }
    void LevelProgressTracker()
    {
        if (QuestionNumberInSet > 5)
        {
           questionNumberInSet = 0;
           waitingForUserAnswer = false;
            if (currentScene == 5)
            {
                currentScene = (int)Random.Range(6, 8);
                SceneManager.LoadScene(currentScene);
            }
            else
            {
                currentScene++;
                SceneManager.LoadScene(currentScene);
            }
        }
    }
}
