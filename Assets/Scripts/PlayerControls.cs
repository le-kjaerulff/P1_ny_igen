using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    QuestionsAudioPlayer questionsAudioPlayer;
    GameManager gameManager;
    UserAnswerChecker userAnswerChecker;


    //public bool cowWasPicked;                       // bools som er sande n�r deres respektive dyr st�r p� svar-pladen
    //public bool pigWasPicked;
    //public bool sheepWasPicked;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        questionsAudioPlayer = this.GetComponent<QuestionsAudioPlayer>();
        userAnswerChecker = this.GetComponent<UserAnswerChecker>();
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



