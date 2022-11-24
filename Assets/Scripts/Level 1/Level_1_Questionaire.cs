using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level_1_Questionaire : MonoBehaviour
{

    [SerializeField] string[] whatAnimal = new string[3]; 
    int rightAnswer;
    int userAnswer;

    bool cowWasPicked;
    bool pigWasPicked;
    bool sheepWasPicked;


    // Start is called before the first frame update
    void Start()
    {
        AskQuestion();
       

    }

    // Update is called once per frame
    void Update()
    {
        cowWasPicked |= Input.GetKeyDown(KeyCode.K);
        pigWasPicked |= Input.GetKeyDown(KeyCode.G);
        sheepWasPicked |= Input.GetKeyDown(KeyCode.F);

    }

    private void FixedUpdate()
    {
        if (cowWasPicked)
        {
            userAnswer = 0;
            if (userAnswer == rightAnswer)
            {
                Debug.Log("GG");
               
            }
            Debug.LogFormat("User answer: {0}", userAnswer);
            Debug.LogFormat("Right answer: {0}", rightAnswer);
            AskQuestion();
        }

        if (pigWasPicked)
        {
            userAnswer = 1;
            if (userAnswer == rightAnswer)
            {
                Debug.Log("GG");
             
            }
            Debug.LogFormat("User answer: {0}", userAnswer);
            Debug.LogFormat("Right answer: {0}", rightAnswer);
            AskQuestion();
        }

        if (sheepWasPicked)
        {
            userAnswer = 2;
            if (userAnswer == rightAnswer)
            {
                Debug.Log("GG");
            }
            Debug.LogFormat("User answer: {0}", userAnswer);
            Debug.LogFormat("Right answer: {0}", rightAnswer);
            AskQuestion();
        }

        cowWasPicked = false;
        pigWasPicked = false;
        sheepWasPicked = false; 
    }

        public void AskQuestion()
    {
        rightAnswer = (int)Random.Range(0, 3);
        Debug.LogFormat("Pick the {0}", whatAnimal[rightAnswer]);
    }



}
