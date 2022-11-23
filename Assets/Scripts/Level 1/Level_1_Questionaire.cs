using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level_1_Questionaire : MonoBehaviour
{

    [SerializeField] AudioSource audioPlayer;
    [SerializeField] AudioClip[] audioClipArray;

    [SerializeField] string[] whatAnimal = new string[3]; 
    int rightAnswer;
    int userAnswer;


    bool cowOnPlate;
    bool pigOnPlate;
    bool sheepOnPlate;

    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
       
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        AskQuestion();
      

    }

    // Update is called once per frame
    void Update()
    {
        cowOnPlate |= Input.GetKeyDown(KeyCode.LeftArrow);
        pigOnPlate |= Input.GetKeyDown(KeyCode.UpArrow);
        sheepOnPlate |= Input.GetKeyDown(KeyCode.RightArrow);

    }

    private void FixedUpdate()
    {
        if (cowOnPlate)
        {
            CowWasPicked();
        }

        if (pigOnPlate)
        {
            PigWasPicked();
        }

        if (sheepOnPlate)
        {
            SheepWasPicked();
        }
        cowOnPlate = false;
        pigOnPlate = false;
        sheepOnPlate = false;
    }

        public void AskQuestion()
    {

        rightAnswer = (int)Random.Range(0, 3);   
        audioPlayer.clip = audioClipArray[rightAnswer];
        audioPlayer.PlayOneShot(audioClipArray[3]);
        audioPlayer.PlayDelayed(audioClipArray[3].length);       
        
        Debug.LogFormat("Pick the {0}", whatAnimal[rightAnswer]);
       
    }

    void CowWasPicked()
    {
        userAnswer = 0;

        if (userAnswer == rightAnswer)
        {
            Debug.Log("GG");
            gameManager.score += 1;
        }
        else
        {
            gameManager.numberOfErrorsInSet += 1;
        }
        gameManager.questionNumberInSet += 1;
        AskQuestion();
    }
    
    void PigWasPicked()
    {
        userAnswer = 1;


        if (userAnswer == rightAnswer)
        {
            Debug.Log("GG");
            gameManager.score += 1;
        }
        gameManager.questionNumberInSet += 1;
        AskQuestion();
    }

    void SheepWasPicked()
    {
        userAnswer = 2;

        if (userAnswer == rightAnswer)
        {
            Debug.Log("GG");
            gameManager.score += 1;
        }
        gameManager.questionNumberInSet += 1;
        AskQuestion();
    }

}


