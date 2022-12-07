using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    QuestionsAudioPlayer questionsAudioPlayer;
    GameManager gameManager;
    UserAnswerChecker userAnswerChecker;
    Animator cowAnimator;
    Animator pigAnimator;
    Animator sheepAnimator;


    //public bool cowWasPicked;                       // bools som er sande n�r deres respektive dyr st�r p� svar-pladen
    //public bool pigWasPicked;
    //public bool sheepWasPicked;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        questionsAudioPlayer = this.GetComponent<QuestionsAudioPlayer>();
        userAnswerChecker = this.GetComponent<UserAnswerChecker>();
        cowAnimator = GameObject.Find("cow sprite sheet_0").GetComponent<Animator>();
        pigAnimator = GameObject.Find("pig sprite sheet_0").GetComponent<Animator>();
        sheepAnimator = GameObject.Find("sheep sprite sheet_0").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UserAnswerInput();
        SetupForNextQuestion();
    }

    void UserAnswerInput()
    {
        if (gameManager.waitingForUserAnswer && !questionsAudioPlayer.audioPlayer.isPlaying && Input.GetKeyDown(KeyCode.LeftArrow)) // cow picked
        {
            switch (gameManager.questionTypeForScene[gameManager.currentScene])
            {
                case "noun":
                    userAnswerChecker.CheckNoun(userAnswerChecker.cowAnswerValue);                  
                    break;

                case "preposition":
                    userAnswerChecker.CheckPreposition(userAnswerChecker.cowAnswerValue);
                    break;

                default:
                    break;
            }
            cowAnimator.SetTrigger("CowWasPicked");
            questionsAudioPlayer.PlayAnswerFeedback(0);

        }

        if (gameManager.waitingForUserAnswer && !questionsAudioPlayer.audioPlayer.isPlaying && Input.GetKeyDown(KeyCode.UpArrow)) // Pig picked
        {
            switch (gameManager.questionTypeForScene[gameManager.currentScene])
            {
                case "noun":
                    userAnswerChecker.CheckNoun(userAnswerChecker.pigAnswerValue);
                    break;

                case "preposition":
                    userAnswerChecker.CheckPreposition(userAnswerChecker.pigAnswerValue);
                    break;

                default:
                    break;
            }
            pigAnimator.SetTrigger("PigWasPicked");
            questionsAudioPlayer.PlayAnswerFeedback(1);
            
        }

        if (gameManager.waitingForUserAnswer && !questionsAudioPlayer.audioPlayer.isPlaying && Input.GetKeyDown(KeyCode.RightArrow)) // Sheep picked
        {
            switch (gameManager.questionTypeForScene[gameManager.currentScene])
            {
                case "noun":
                    userAnswerChecker.CheckNoun(userAnswerChecker.sheepAnswerValue);
                    break;

                case "preposition":
                    userAnswerChecker.CheckPreposition(userAnswerChecker.sheepAnswerValue);
                    break;

                default:
                    break;
            }
            sheepAnimator.SetTrigger("SheepWasPicked");
            questionsAudioPlayer.PlayAnswerFeedback(2);
            
        }
    }

    void SetupForNextQuestion()
    {
        if (!gameManager.readyForNextQuestion && !gameManager.waitingForUserAnswer &&
       Input.GetKey(KeyCode.Q))  // all animals "home"
        {
            gameManager.readyForNextQuestion = true;
        }
    }


}



