using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControls : MonoBehaviour
{
    QuestionsAudioPlayer questionsAudioPlayer;
    GameManager gameManager;
    UserAnswerChecker userAnswerChecker;
    Animator cowAnimator;
    Animator pigAnimator;
    Animator sheepAnimator;
    QuestionGenerator questionGenerator;
    

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        questionsAudioPlayer = this.GetComponent<QuestionsAudioPlayer>();
        userAnswerChecker = this.GetComponent<UserAnswerChecker>();
        cowAnimator = GameObject.Find("cow sprite sheet_0").GetComponent<Animator>();
        pigAnimator = GameObject.Find("pig sprite sheet_0").GetComponent<Animator>();
        sheepAnimator = GameObject.Find("sheep sprite sheet_0").GetComponent<Animator>();
        questionGenerator = this.GetComponent<QuestionGenerator>();
        
    }

    void Update()
    {
        UserControls();
        TestAdminControls();
    }

    void UserControls()
    {
        if (gameManager.waitingForUserAnswer && !questionsAudioPlayer.audioPlayer.isPlaying // cow picked
            && Input.GetKeyDown(KeyCode.LeftArrow)) 
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
        if (gameManager.waitingForUserAnswer && !questionsAudioPlayer.audioPlayer.isPlaying // Pig picked
            && Input.GetKeyDown(KeyCode.UpArrow)) 
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

        if (gameManager.waitingForUserAnswer && !questionsAudioPlayer.audioPlayer.isPlaying // Sheep picked
            && Input.GetKeyDown(KeyCode.RightArrow)) 
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

    void TestAdminControls()
    {
        if (!gameManager.waitingForUserAnswer && Input.GetKeyDown(KeyCode.Q))  // play next question/level
        {
            gameManager.questionNumberInSet++;           
            if(gameManager.questionNumberInSet <= 5)
            {
                questionGenerator.AskQuestion(gameManager.questionTypeForScene[gameManager.currentScene]);
            }                      
        }

        if (gameManager.waitingForUserAnswer && Input.GetKeyDown(KeyCode.R))   // repeat current question
        {
            switch (gameManager.questionTypeForScene[gameManager.currentScene])
            {
                case "noun":
                    questionsAudioPlayer.PlayNounQuestionAudio(questionGenerator.nounAsked);
                    break;

                case "preposition":
                    questionsAudioPlayer.PlayPrepositionQuestionAudio(questionGenerator.positionAsked);
                    break;
            }
        } 
    }
}



