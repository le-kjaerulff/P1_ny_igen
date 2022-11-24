using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2questionaire : MonoBehaviour
{
    int rightAnswer;
    int A;
    int B;
    int C;

    int previousA;
    int previousB;
    int previousC;

    bool itsTheSame;


    // Start is called before the first frame update
    void Start()
    {
        AskQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        NoRepetition();
    }

    
    
    
    
    
    
    
    public void AskQuestion()
    {

       // rightAnswer = (int)Random.Range(0, 3);
        A = (int)Random.Range(0, 3);
        B = (int)Random.Range(0, 3);
        C = (int)Random.Range(0, 3);
        while (A == B || B == C || C == A || itsTheSame == true){
        B = (int)Random.Range(0, 3);
        C = (int)Random.Range(0, 3);
        }
  
        Debug.LogFormat("A: {0}. B: {1}. C: {2}", A, B, C);

        previousA = A;
        previousB = B;
        previousC = C;


    }

    void NoRepetition()
    {
        if(A == previousA && B == previousB && C == previousC)
        {
            itsTheSame = true;
        }
    }




}
