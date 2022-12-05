using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level_1_Questionaire : MonoBehaviour
{

    [SerializeField] AudioSource audioPlayer;
    [SerializeField] AudioClip[] audioClipArray;

    [SerializeField] string[] whatAnimal = new string[3];
    public int verbumAsked;

    public int cow = 0;
    public int pig = 1;
    public int sheep = 2;

    


    // Start is called before the first frame update
    void Start()
    {
        AskQuestion();
    }

    

    public void AskQuestion()
    {

        verbumAsked = (int)Random.Range(0, 3);
        audioPlayer.clip = audioClipArray[verbumAsked];
        audioPlayer.PlayOneShot(audioClipArray[3]);
        audioPlayer.PlayDelayed(audioClipArray[3].length);

        Debug.LogFormat("Pick the {0}", whatAnimal[verbumAsked]);

    }

   

}
