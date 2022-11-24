using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2questionaire : MonoBehaviour
{

    GameObject cow;
    GameObject pig;
    GameObject sheep;

    public GameObject cowSprite;
    public GameObject pigSprite;
    public GameObject sheepSprite;

    public GameObject cowHeadSprite;
    public GameObject pigHeadSprite;
    public GameObject sheepHeadSprite;




    //int rightAnswer;
    int cowPosition;
    int pigPosition;
    int sheepPosition;

    int previousCowPosition;
    int previousPigPosition;
    int previousSheepPosition;

    bool shuffle;

    public Vector2[] cowPlacements = new Vector2[]
    {
        new Vector2( 0, 0), // [0] foran
        new Vector2( 0, 0),    // [1] ved siden af
        new Vector2( 0, 0) // [2] inden i
    };

    public Vector2[] pigPlacements = new Vector2[]
 {
        new Vector2( 0, 0), // [0] foran
        new Vector2( 0, 0),    // [1] ved siden af
        new Vector2( 0, 0) // [2] inden i
 };

    public Vector2[] sheepPlacements = new Vector2[]
 {
        new Vector2( 0, 0), // [0] foran
        new Vector2( 0, 0),    // [1] ved siden af
        new Vector2( 0, 0) // [2] inden i
 };



    // Start is called before the first frame update
    void Start()
    {
       
        cow = GameObject.Find("Cow");
        pig = GameObject.Find("Pig");
        sheep = GameObject.Find("Sheep");
        AskQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        shuffle |= Input.GetKeyDown(KeyCode.Space);

        PositionUpdater();
        if (shuffle)
        {
            AskQuestion();
        }
        shuffle = false;

        spriteShift();
       
    }

    public void AskQuestion()
    {
        updatePrevious();
        //rightAnswer = (int)Random.Range(0, 3);
        cowPosition = (int)Random.Range(0, 3);
        pigPosition = (int)Random.Range(0, 3);
        sheepPosition = (int)Random.Range(0, 3);
        while (cowPosition == pigPosition || pigPosition == sheepPosition || sheepPosition == cowPosition || 
            cowPosition == previousCowPosition && pigPosition == previousPigPosition && sheepPosition == previousSheepPosition)
        {
        cowPosition = (int)Random.Range(0, 3);
        pigPosition = (int)Random.Range(0, 3);
        sheepPosition = (int)Random.Range(0, 3);
        }

        Debug.LogFormat("Ko: {0}. Gris: {1}. Får: {2}", cowPosition, pigPosition, sheepPosition);
    }

    public void updatePrevious()
    {
        previousCowPosition = cowPosition;
        previousPigPosition = pigPosition;
        previousSheepPosition = sheepPosition;
    }

   void PositionUpdater()
   {
       cow.GetComponent<Transform>().position = cowPlacements[cowPosition];
       pig.GetComponent<Transform>().position = pigPlacements[pigPosition];
       sheep.GetComponent<Transform>().position = sheepPlacements[sheepPosition];
    }

    void spriteShift()
    {
        if (cowPosition == 2)
        {
            cowHeadSprite.gameObject.SetActive(true);
            cowSprite.gameObject.SetActive(false);

        }
        else
        {
            cowHeadSprite.gameObject.SetActive(false);
            cowSprite.gameObject.SetActive(true);
        }
        
        if(pigPosition == 2)
        {
            pigHeadSprite.gameObject.SetActive(true);
            pigSprite.gameObject.SetActive(false);

        }
        else
        {
            pigHeadSprite.gameObject.SetActive(false);
            pigSprite.gameObject.SetActive(true);
        }

        if(sheepPosition == 2)
        {
            sheepHeadSprite.gameObject.SetActive(true);
            sheepSprite.gameObject.SetActive(false);

        }
        else
        {
            sheepHeadSprite.gameObject.SetActive(false);
            sheepSprite.gameObject.SetActive(true);
        }





    }




}
