using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tutorial : MonoBehaviour
{

    [SerializeField] AudioSource audioPlayer;
    [SerializeField] AudioClip[] audioClipArray;

    [SerializeField] string[] whatAnimal = new string[3];
    public GameManager gameManager;
    int rightAnswer;
    int UserAnswer;


    bool cowOnPlate;
    bool pigOnPlate;
    bool sheepOnPlate;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        AskQuestion();
    }

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
        UserAnswer = 0;
        AskQuestion();
    }

    void PigWasPicked()
    {
        UserAnswer = 1;
        AskQuestion();
    }

    void SheepWasPicked()
    {
        UserAnswer = 2;
        AskQuestion();
    }

}


