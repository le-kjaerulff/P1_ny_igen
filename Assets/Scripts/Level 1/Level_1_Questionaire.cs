using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level_1_Questionaire : MonoBehaviour
{

    [SerializeField] string[] hvilketDyr = new string[3]; 
    int rightAnswer;
    int userAnswer;

    bool koenValgt;
    bool grisenValgt;
    bool faaretValgt;


    // Start is called before the first frame update
    void Start()
    {
        AskQuestion();
       

    }

    // Update is called once per frame
    void Update()
    {
        koenValgt |= Input.GetKeyDown(KeyCode.K);
        grisenValgt |= Input.GetKeyDown(KeyCode.G);
        faaretValgt |= Input.GetKeyDown(KeyCode.F);

    }

    private void FixedUpdate()
    {
        if (koenValgt)
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

        if (grisenValgt)
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

        if (faaretValgt)
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

        koenValgt = false;
        grisenValgt = false;
        faaretValgt = false; 
    }

        public void AskQuestion()
    {
        rightAnswer = (int)Random.Range(0, 3);
        Debug.LogFormat("Vælg {0}", hvilketDyr[rightAnswer]);
    }



}
