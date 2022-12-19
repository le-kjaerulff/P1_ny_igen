using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionGenerator : MonoBehaviour
{
    GameManager gameManager;
    PositionRandomizer positionRandomizer;
    QuestionsAudioPlayer questionsAudioPlayer;
    UserAnswerChecker userAnswerChecker;

    public int nounAsked;
    public int positionAsked;
    
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        positionRandomizer = this.GetComponent<PositionRandomizer>();
        questionsAudioPlayer = this.GetComponent<QuestionsAudioPlayer>();
        userAnswerChecker = this.GetComponent<UserAnswerChecker>();
    }

    public void AskQuestion(string type)
    {
        switch (type)
        {
            case "noun":
                nounAsked = (int)Random.Range(0, 3);
                
                userAnswerChecker.cowAnswerValue = 0;
                userAnswerChecker.pigAnswerValue = 1;
                userAnswerChecker.sheepAnswerValue = 2;

                questionsAudioPlayer.PlayNounQuestionAudio(nounAsked);
                break;

            case "preposition":
                positionRandomizer.RandomizePositions();

                positionAsked = positionRandomizer.currentConfig[(int)Random.Range(0, 3)]; // et tal mellem de nuværende værdier i currentconfig udtrækkes tilfældigt 

                userAnswerChecker.cowAnswerValue = positionRandomizer.currentConfig[0];
                userAnswerChecker.pigAnswerValue = positionRandomizer.currentConfig[1];
                userAnswerChecker.sheepAnswerValue = positionRandomizer.currentConfig[2];

                questionsAudioPlayer.PlayPrepositionQuestionAudio(positionAsked);

                break;
        }
        gameManager.waitingForUserAnswer = true;
    }
}
