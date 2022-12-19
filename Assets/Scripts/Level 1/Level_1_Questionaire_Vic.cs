using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level_1_Questionaire_Vic : MonoBehaviour
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
    // Kode gjort kortere her ved at kalde AnimalWasPicked i stedet for at have tre ens metoder. Det er godt hvis man skal rette i koden, for så skal man kun gøre det et sted.
    private void FixedUpdate()
    {
        if (cowOnPlate)
        {
            AnimalWasPicked(0);
        }

        if (pigOnPlate)
        {
            AnimalWasPicked(1);
        }

        if (sheepOnPlate)
        {
            AnimalWasPicked(2);
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

    void AnimalWasPicked(int animalId)
    {
        userAnswer = animalId;
        // for at debgge hvad der er trykket på og se om der er lavet en fejl, evt ved at et andet script er sat til en anden value end forvendtet. 
        // Neden under er vist det forventede rigtige svar til sprøgsmålet. {0} bliver erstattet af første parameter som er userAnswer her:
        Debug.LogFormat("userAnswer: {0}", userAnswer);
        Debug.LogFormat("rightAnswer: {0}", rightAnswer);

        // Den tager brugers svar og tjekker på om det er det rigtige svar her ved if:
        if (userAnswer == rightAnswer)
        {
            Debug.Log("GG");
            gameManager.playerScore++; // += 1, er erstattet med ++, det er huritgere at skrive.
        }
        //else
        //{
        //    gameManager.numberOfErrorsInSet++;
        //}
        gameManager.questionNumberInSet++;
        AskQuestion();
    }
       

} 


