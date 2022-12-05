using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private int _playerScore = 0;
    private int _difficultyLevel;
    [SerializeField] int _questionNumberInSet;
    private int _numberOfErrorsInSet;

    public bool readyForNextQuestion;
    public bool waitingForUserAnswer;

    public int questionNumberInSet
    {
        get
        {
            return _questionNumberInSet;
        }
        set
        {
            _questionNumberInSet = value;
            Debug.LogFormat("This is question number {0}", _questionNumberInSet);
        }
    }
    public int numberOfErrorsInSet
    {
        get
        {
            return _numberOfErrorsInSet;
        }
        set
        {
           _numberOfErrorsInSet = value;
           // Debug.LogFormat("Errors: {0}", _numberOfErrorsInSet);
        }
    }
    public int playerScore
    {
        get { return _playerScore;
        }
        set
        {
            _playerScore = value;
           // Debug.LogFormat("Score: {0}", _playerScore);
        }
    }

    public int difficultyLevel
    {
        get
        {
            return _difficultyLevel;
        }
        set
        {
            _difficultyLevel = value;
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


    private void Start()
    {      
        questionNumberInSet = 1;
        numberOfErrorsInSet = 0;
    }


    private void Update()
    {
        LevelProgression();
    }

    void LevelProgression()
    {
        if (_questionNumberInSet > 5)
        {
            questionNumberInSet = 1;
            currentScene++;
            SceneManager.LoadScene(currentScene);
            //if (numberOfErrorsInSet == 0)
            //{              
            //    difficultyLevel += 1;
            //    numberOfErrorsInSet = 0;                
            //    Debug.LogFormat("Difficulty is now: {0}", _difficultyLevel);
            //    SceneManager.LoadScene(currentScene += 1); 
            //}
        }






    }






}
