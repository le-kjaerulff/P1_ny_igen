using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3questionaire : MonoBehaviour
{
    GameManager gameManager;                        // GamemManager class 
    PlayerControls playerControls;
    //QuestionsAudioPlayer questionsAudioPlayer;

    GameObject cow;                                 // gameobjects til at flytte dyrene
    GameObject pig;
    GameObject sheep;

    public GameObject cowSprite;                    // gameobjects til at skifte ml. hele dyr og hoveder
    public GameObject pigSprite;
    public GameObject sheepSprite;

    public GameObject cowHeadSprite;
    public GameObject pigHeadSprite;
    public GameObject sheepHeadSprite;

    public int cowPosition;                                // Int variabler som holder styr på index-numre for dyrenes aktuelle vector2 positioner
    public int pigPosition;
    public int sheepPosition;

    int previousCowPosition;                        // Int variabler som holder styr på index-numre for dyrenes forgående vector2 positioner
    int previousPigPosition;
    int previousSheepPosition;

    public int[] currentConfig = new int[3];               // int-array som gemmer de tre index-numre for dyrenes aktuelle vector2 positioner
    //public int positionAsked;                       // int som gemmer index-nummer for den placering der nævnes i det aktuelle spørgsmål
    /*int userAnswer;     */                            // int som gemmer index-nummer for vector2 positionen af det dyr brugeren vælger

   
   
    public Vector2[] possibleCowPositions = new Vector2[]
    {
        new Vector2( 0, 0),     
        new Vector2( 0, 0),     
        new Vector2( 0, 0),     
        new Vector2( 0, 0),       
        new Vector2( 0, 0),
        new Vector2( 0, 0),
        new Vector2( 0, 0),
        new Vector2( 0, 0)
    };  //vector2 arrays som holder alle mulige positioner for de tre dyr

    public Vector2[] possiblePigPositions = new Vector2[]
 {
        new Vector2( 0, 0),      
        new Vector2( 0, 0),      
        new Vector2( 0, 0),      
        new Vector2( 0, 0),      
        new Vector2( 0, 0),
        new Vector2( 0, 0),
        new Vector2( 0, 0),
        new Vector2( 0, 0)
 };

    public Vector2[] possibleSheepPositions = new Vector2[]
 {
        new Vector2( 0, 0),      // [0] foran
        new Vector2( 0, 0),      // [1] ved siden af
        new Vector2( 0, 0),      // [2] inden i
        new Vector2( 0, 0),      // [3] bag ved
        new Vector2( 0, 0),
        new Vector2( 0, 0),
        new Vector2( 0, 0),
        new Vector2( 0, 0)
 };

    //string[] positionSounds = new string[] { "foran træet", "ved siden af træet", "inden i træet", "bag ved træet", "foran laden", "ovenpå laden", "inden i laden", "bagved laden" };   // array som holder tekstbaserede spørgsmålsvariationer til debugging

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();  // spillets gamemanager object findes og gemmes
        playerControls = this.GetComponent<PlayerControls>();
        //questionsAudioPlayer = this.GetComponent<QuestionsAudioPlayer>();
        cow =   GameObject.Find("Cow");                                               // dyrenes parent objects findes og gemmes
        pig =   GameObject.Find("Pig");
        sheep = GameObject.Find("Sheep");

        //RandomizePositions();                                  
    }




    // Update is called once per frame
    void Update()
    {
       
        //PositionUpdater();


        //if (playerControls.cowOnPlate)                     
        //{
        //    UserAnswerCheck(cowPosition);
        //}

        //if (playerControls.pigOnPlate)
        //{
        //    UserAnswerCheck(pigPosition);
        //}

        //if (playerControls.sheepOnPlate)
        //{
        //    UserAnswerCheck(sheepPosition);
        //}

        //SpriteShift();
        //LayerShift();

     
      
    }

    //public void RandomizePositions()
    //{
    //    updatePrevious();

    //    cowPosition = (int)Random.Range(0, 8);  // tilfældige tal ml. 0 og 7, svarende til vector2 arrays'snes indexnumre, tilskrives til de tre positionsvariabler. 
    //    pigPosition = (int)Random.Range(0, 8);
    //    sheepPosition = (int)Random.Range(0, 8);
    //    while (cowPosition == pigPosition || pigPosition == sheepPosition || sheepPosition == cowPosition ||
    //        cowPosition == previousCowPosition && pigPosition == previousPigPosition && sheepPosition == previousSheepPosition) // hvis nogle af dyrene får det samme tal, eller alle positioner er de samme som 
    //                                                                                                                            // i foregående spørgsmål, tilskrives nye tilfældige værdier.
    //    {
    //        cowPosition = (int)Random.Range(0, 8);
    //        pigPosition = (int)Random.Range(0, 8);
    //        sheepPosition = (int)Random.Range(0, 8);
    //    }

    //    currentConfig[0] = cowPosition;     // currentconfig arrayet opdateres med de nye positioner
    //    currentConfig[1] = pigPosition;
    //    currentConfig[2] = sheepPosition;

       // positionAsked = currentConfig[(int)Random.Range(0, 3)]; // et tal mellem de nuværende værdier i currentconfig udtrækkes tilfældigt 

        //questionsAudioPlayer.PlayQuestionAudio(positionAsked);
        

        //Debug.LogFormat("Ko: {0}. Gris: {1}. Får: {2}", cowPosition, pigPosition, sheepPosition); 
        //Debug.LogFormat("Hvilket dyr er {0}?", positionSounds[positionAsked]);
    //}

    //public void updatePrevious()    // gemmer de tidligere positioner inden de overskrives med nye positioner
    //{
    //    previousCowPosition = cowPosition;
    //    previousPigPosition = pigPosition;
    //    previousSheepPosition = sheepPosition;
    //}

    //void PositionUpdater()          // Opdaterer dyrenes positioner ved at tage det tal de hver især får tilskrevet tilfældigt, og sætte dem ind som index-numre i dyrenes egne vector2 arrays. 
    //{
    //    cow.GetComponent<Transform>().position = possibleCowPositions[cowPosition]; // alle disse er vector2-værdier
    //    pig.GetComponent<Transform>().position = possiblePigPositions[pigPosition];
    //    sheep.GetComponent<Transform>().position = possibleSheepPositions[sheepPosition];
    //}

    //void SpriteShift()
    //{
    //    if (cowPosition == 2 || cowPosition == 6)
    //    {
    //        cowHeadSprite.gameObject.SetActive(true);
    //        cowSprite.gameObject.SetActive(false);

    //    }
    //    else
    //    {
    //        cowHeadSprite.SetActive(false);
    //        cowSprite.SetActive(true);
    //    }

    //    if (pigPosition == 2 || pigPosition == 6)
    //    {
    //        pigHeadSprite.gameObject.SetActive(true);
    //        pigSprite.gameObject.SetActive(false);

    //    }
    //    else
    //    {
    //        pigHeadSprite.gameObject.SetActive(false);
    //        pigSprite.gameObject.SetActive(true);
    //    }

    //    if (sheepPosition == 2 || sheepPosition == 6)
    //    {
    //        sheepHeadSprite.gameObject.SetActive(true);
    //        sheepSprite.gameObject.SetActive(false);

    //    }
    //    else
    //    {
    //        sheepHeadSprite.gameObject.SetActive(false);
    //        sheepSprite.gameObject.SetActive(true);
    //    }


    //} // sørger for at skifte mellem hoved-sprites og almindelige sprites

    //void LayerShift()
    //{
    //    if (cowPosition == 3 || cowPosition == 7)
    //    {
    //        cowSprite.GetComponent<SpriteRenderer>().sortingLayerName = "Default";

    //    }
    //    else
    //    {
    //        cowSprite.GetComponent<SpriteRenderer>().sortingLayerName = "forgrund";
    //    }

    //    if (pigPosition == 3 || pigPosition == 7)
    //    {
    //        pigSprite.GetComponent<SpriteRenderer>().sortingLayerName = "Default";

    //    }
    //    else
    //    {
    //        pigSprite.GetComponent<SpriteRenderer>().sortingLayerName = "forgrund";
    //    }

    //    if (sheepPosition == 3 || sheepPosition == 7)
    //    {
    //        sheepSprite.GetComponent<SpriteRenderer>().sortingLayerName = "Default";

    //    }
    //    else
    //    {
    //        sheepSprite.GetComponent<SpriteRenderer>().sortingLayerName = "forgrund";
    //    }

    //}   // rykker dyrene rundt i lag hvis de skal stå foran eller bagved noget 

    //void UserAnswerCheck(int pickedAnimalPosition)
    //{
    //    userAnswer = pickedAnimalPosition; // userAnswer for den int som er associeret med det valgte dyrs position. 

    //    if (userAnswer == positionAsked)    // rigigt svar
    //    {
    //        Debug.Log("Yuo are smart!");
    //        gameManager.playerScore += 1;
    //    }
    //    else
    //    {                                   // forkert svar
    //        gameManager.numberOfErrorsInSet += 1;
    //    }
    //    gameManager.questionNumberInSet += 1;
    //    RandomizePositions();
    //}
}
