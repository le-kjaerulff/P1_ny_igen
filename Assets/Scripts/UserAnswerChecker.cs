using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserAnswerChecker : MonoBehaviour
{
    GameManager gameManager;
    PositionRandomizer positionRandomizer;
    PlayerControls playerControls;
    QuestionGenerator questionGenerator;
    

    //int userAnswer;

    public int cowAnswerValue;
    public int pigAnswerValue;
    public int sheepAnswerValue;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();  // spillets gamemanager object findes og gemmes
        playerControls = this.GetComponent<PlayerControls>();
        positionRandomizer = this.GetComponent<PositionRandomizer>();
        questionGenerator = this.GetComponent<QuestionGenerator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //userAnswerPickup(); 
    }

  

    public void CheckPreposition(int AnimalAnswerValue)
    {
        if (AnimalAnswerValue == questionGenerator.positionAsked)    // rigigt svar
        {
            Debug.Log("Yuo are smart!");
            gameManager.playerScore ++;
        }
        else
        {                                   // forkert svar
            gameManager.numberOfErrorsInSet ++;
        }
        gameManager.waitingForUserAnswer = false;
        gameManager.questionNumberInSet ++;
        
        //questionGenerator.AskQuestion(gameManager.questionTypeForScene[gameManager.currentScene]);

    }

    public void CheckNoun(int AnimaAnswerValue)
    {
        
        // for at debgge hvad der er trykket på og se om der er lavet en fejl, evt ved at et andet script er sat til en anden value end forvendtet. 
        // Neden under er vist det forventede rigtige svar til sprøgsmålet. {0} bliver erstattet af første parameter som er userAnswer her:
        //Debug.LogFormat("userAnswer: {0}", userAnswer);
        //Debug.LogFormat("rightAnswer: {0}", pickedAnimal);

        // Den tager brugers svar og tjekker på om det er det rigtige svar her ved if:
        if (AnimaAnswerValue == questionGenerator.nounAsked)
        {
            Debug.Log("GG");
            gameManager.playerScore++; // += 1, er erstattet med ++, det er huritgere at skrive.
        }
        else
        {
            gameManager.numberOfErrorsInSet++;
        }
        gameManager.waitingForUserAnswer = false;
        gameManager.questionNumberInSet++;
        
        //questionGenerator.AskQuestion(gameManager.questionTypeForScene[gameManager.currentScene]);
    }
    
    //void userAnswerPickup()
    //{
    //    if (playerControls.cowWasPicked)
    //    {
    //        playerControls.cowWasPicked = false;
    //        switch (gameManager.questionTypeForScene[gameManager.currentScene])
    //        {
    //            case "noun":
    //                CheckNoun(cowAnswerValue);
    //                break;

    //            case "preposition":
    //                CheckPreposition(cowAnswerValue);
    //                break;

    //            default:
    //                break;
    //        }
    //    }

    //    if (playerControls.pigWasPicked)
    //    {
    //        playerControls.pigWasPicked = false;
    //        switch (gameManager.questionTypeForScene[gameManager.currentScene])
    //        {
    //            case "noun":
    //                CheckNoun(pigAnswerValue);
    //                break;

    //            case "preposition":
    //                CheckPreposition(pigAnswerValue);
    //                break;

    //            default:
    //                break;
    //        }
    //    }

    //    if (playerControls.sheepWasPicked)
    //    {
    //        playerControls.sheepWasPicked = false;
    //        switch (gameManager.questionTypeForScene[gameManager.currentScene])
    //        {
    //            case "noun":
    //                CheckNoun(sheepAnswerValue);
    //                break;

    //            case "preposition":
    //                CheckPreposition(sheepAnswerValue);
    //                break;

    //            default:
    //                break;
    //        }

    //    }
    //}

   




}