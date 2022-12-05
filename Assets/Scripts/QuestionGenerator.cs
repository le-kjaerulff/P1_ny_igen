using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionGenerator : MonoBehaviour
{
    GameManager gameManager;
    PositionRandomizer positionRandomizer;
    QuestionsAudioPlayer questionsAudioPlayer;
    UserAnswerChecker userAnswerChecker;
    PlayerControls playerControls;

    //public int cow = 0;
    //public int pig = 1;
    //public int sheep = 2;

    public int nounAsked;
    public int positionAsked;
    string[] positionSounds = new string[] { "foran træet", "ved siden af træet", "inden i træet", "bag ved træet", "foran laden", "ovenpå laden", "inden i laden", "bagved laden" };
    [SerializeField] string[] whatAnimal = new string[3];
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        positionRandomizer = this.GetComponent<PositionRandomizer>();
        questionsAudioPlayer = this.GetComponent<QuestionsAudioPlayer>();
        userAnswerChecker = this.GetComponent<UserAnswerChecker>();
        playerControls = this.GetComponent<PlayerControls>();
        
        //AskQuestion(gameManager.questionTypeForScene[gameManager.currentScene]);
    }

    private void Update()
    {
        if (gameManager.readyForNextQuestion && !gameManager.waitingForUserAnswer)
        {
            AskQuestion(gameManager.questionTypeForScene[gameManager.currentScene]);         
        }
    }

    public void AskQuestion(string type)
    {
        gameManager.readyForNextQuestion = false;
        gameManager.waitingForUserAnswer = true;

        switch (type)
        {
            case "noun":
                nounAsked = (int)Random.Range(0, 3);
                
                questionsAudioPlayer.PlayNounQuestionAudio(nounAsked);

                userAnswerChecker.cowAnswerValue = 0;
                userAnswerChecker.pigAnswerValue = 1;
                userAnswerChecker.sheepAnswerValue = 2;

                Debug.LogFormat("Pick the {0}", whatAnimal[nounAsked]);

                break;

            case "preposition":
                positionRandomizer.RandomizePositions();

                positionAsked = positionRandomizer.currentConfig[(int)Random.Range(0, 3)]; // et tal mellem de nuværende værdier i currentconfig udtrækkes tilfældigt 

                questionsAudioPlayer.PlayPrepositionQuestionAudio(positionAsked);

                userAnswerChecker.cowAnswerValue = positionRandomizer.currentConfig[0];
                userAnswerChecker.pigAnswerValue = positionRandomizer.currentConfig[1];
                userAnswerChecker.sheepAnswerValue = positionRandomizer.currentConfig[2];
                Debug.LogFormat("Hvilket dyr er {0}?", positionSounds[positionAsked]);

                break;
        }
        
        
    }



}
