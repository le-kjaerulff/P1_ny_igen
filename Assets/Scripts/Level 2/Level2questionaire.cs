using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2questionaire : MonoBehaviour
{

    [SerializeField] AudioSource audioPlayer;
    [SerializeField] AudioClip[] audioClipArray;

    public GameManager gameManager;

    GameObject cow;
    GameObject pig;
    GameObject sheep;

    public GameObject cowSprite;
    public GameObject pigSprite;
    public GameObject sheepSprite;

    public GameObject cowHeadSprite;
    public GameObject pigHeadSprite;
    public GameObject sheepHeadSprite;

    int cowPosition;
    int pigPosition;
    int sheepPosition;

    int previousCowPosition;
    int previousPigPosition;
    int previousSheepPosition;

    int[] currentConfig = new int[3];
    int positionAsked;
    int userAnswer;

    bool shuffle;
    bool cowOnPlate;
    bool pigOnPlate;
    bool sheepOnPlate;

    public Vector2[] cowPlacements = new Vector2[]
    {
        new Vector2( 0, 0),      // [0] foran
        new Vector2( 0, 0),      // [1] ved siden af
        new Vector2( 0, 0),      // [2] inden i
        new Vector2( 0, 0),       // [3] bag ved
        new Vector2( 0, 0),
        new Vector2( 0, 0),
        new Vector2( 0, 0),
        new Vector2( 0, 0)
    };

    public Vector2[] pigPlacements = new Vector2[]
 {
        new Vector2( 0, 0),      // [0] foran
        new Vector2( 0, 0),      // [1] ved siden af
        new Vector2( 0, 0),      // [2] inden i
        new Vector2( 0, 0),       // [3] bag ved
        new Vector2( 0, 0),
        new Vector2( 0, 0),
        new Vector2( 0, 0),
        new Vector2( 0, 0)
 };

    public Vector2[] sheepPlacements = new Vector2[]
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

    string[] positionSounds = new string[] { "foran træet", "ved siden af træet", "inden i træet", "bag ved træet", "foran laden", "ovenpå laden", "inden i laden", "bagved laden" };

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        cow = GameObject.Find("Cow");
        pig = GameObject.Find("Pig");
        sheep = GameObject.Find("Sheep");
  
        AskQuestion();
    }

 


    // Update is called once per frame
    void Update()
    {
        cowOnPlate |= Input.GetKeyDown(KeyCode.LeftArrow);
        pigOnPlate |= Input.GetKeyDown(KeyCode.UpArrow);
        sheepOnPlate |= Input.GetKeyDown(KeyCode.RightArrow);

        PositionUpdater();
       
        if (shuffle)
        {
            AskQuestion();
        }
        
        if (cowOnPlate)
        {
            UserAnswerCheck(cowPosition);
        }

        if (pigOnPlate)
        {
            UserAnswerCheck(pigPosition);
        }

        if (sheepOnPlate)
        {
            UserAnswerCheck(sheepPosition);
        }

        SpriteShift();
        LayerShift();

        shuffle = false;
        cowOnPlate = false;
        pigOnPlate = false;
        sheepOnPlate = false;
    }

    public void AskQuestion()
    {
        updatePrevious();
        
        cowPosition = (int)Random.Range(0, 4);
        pigPosition = (int)Random.Range(0, 4);
        sheepPosition = (int)Random.Range(0, 4);
        while (cowPosition == pigPosition || pigPosition == sheepPosition || sheepPosition == cowPosition ||
            cowPosition == previousCowPosition && pigPosition == previousPigPosition && sheepPosition == previousSheepPosition)
        {
            cowPosition = (int)Random.Range(0, 4);
            pigPosition = (int)Random.Range(0, 4);
            sheepPosition = (int)Random.Range(0, 4);
        }

        currentConfig[0] = cowPosition;
        currentConfig[1] = pigPosition;
        currentConfig[2] = sheepPosition;

        positionAsked = currentConfig[(int)Random.Range(0, 3)];

        audioPlayer.clip = audioClipArray[positionAsked];
        audioPlayer.PlayOneShot(audioClipArray[8]);
        audioPlayer.PlayDelayed(audioClipArray[8].length);

        Debug.LogFormat("Ko: {0}. Gris: {1}. Får: {2}", cowPosition, pigPosition, sheepPosition);
        Debug.LogFormat("Hvilket dyr er {0}?", positionSounds[positionAsked]);
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

    void SpriteShift()
    {
        if (cowPosition == 2 || cowPosition == 6)
        {
            cowHeadSprite.gameObject.SetActive(true);
            cowSprite.gameObject.SetActive(false);

        }
        else
        {
            cowHeadSprite.SetActive(false);
            cowSprite.SetActive(true);
        }

        if (pigPosition == 2 || pigPosition == 6)
        {
            pigHeadSprite.gameObject.SetActive(true);
            pigSprite.gameObject.SetActive(false);

        }
        else
        {
            pigHeadSprite.gameObject.SetActive(false);
            pigSprite.gameObject.SetActive(true);
        }

        if (sheepPosition == 2 || sheepPosition == 6 )
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

    void LayerShift()
    {
        if (cowPosition == 3 || cowPosition == 7)
        {
            cowSprite.GetComponent<SpriteRenderer>().sortingLayerName = "Default";

        }
        else
        {
            cowSprite.GetComponent<SpriteRenderer>().sortingLayerName = "forgrund";
        }

        if (pigPosition == 3 || pigPosition == 7)
        {
            pigSprite.GetComponent<SpriteRenderer>().sortingLayerName = "Default";

        }
        else
        {
            pigSprite.GetComponent<SpriteRenderer>().sortingLayerName = "forgrund";
        }

        if (sheepPosition == 3 || sheepPosition == 7)
        {
            sheepSprite.GetComponent<SpriteRenderer>().sortingLayerName = "Default";

        }
        else
        {
            sheepSprite.GetComponent<SpriteRenderer>().sortingLayerName = "forgrund";
        }

    }

    void UserAnswerCheck(int pickedAnimalPosition)
    {
        userAnswer = pickedAnimalPosition;

        if(userAnswer == positionAsked)
        {
            Debug.Log("Yuo are smart!");
            gameManager.playerScore += 1;
        }
        //else
        //{
        //    gameManager.numberOfErrorsInSet += 1;
        //}
        gameManager.questionNumberInSet += 1;
        AskQuestion();
    }
}
