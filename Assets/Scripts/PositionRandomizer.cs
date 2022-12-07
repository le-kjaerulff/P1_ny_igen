using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRandomizer : MonoBehaviour
{
    GameObject cow;                                 // gameobjects til at flytte dyrene
    GameObject pig;
    GameObject sheep;

    public GameObject cowSprite;                    // gameobjects til at skifte ml. hele dyr og hoveder
    public GameObject pigSprite;
    public GameObject sheepSprite;
    public GameObject cowHeadSprite;
    public GameObject pigHeadSprite;
    public GameObject sheepHeadSprite;

    public int cowPosition;                                // Int variabler som holder styr p� index-numre for dyrenes aktuelle vector2 positioner
    public int pigPosition;
    public int sheepPosition;

    int previousCowPosition;                        // Int variabler som holder styr p� index-numre for dyrenes forg�ende vector2 positioner
    int previousPigPosition;
    int previousSheepPosition;

    public int[] currentConfig = new int[3];        // int-array som gemmer de tre index-numre for dyrenes aktuelle vector2 positioner

    public int numberOfPossiblePositions;

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



    // Start is called before the first frame update
    void Awake()
    {
        cow = GameObject.Find("Cow");           // dyrenes parent objects findes og gemmes
        pig = GameObject.Find("Pig");
        sheep = GameObject.Find("Sheep");
        RandomizePositions();
    }

    // Update is called once per frame
    void Update()
    {
        PositionUpdater();
        SpriteUpdater();
        LayerUpdater();
    }

    public void RandomizePositions()
    {
        UpdatePrevious();

        cowPosition = (int)Random.Range(0, numberOfPossiblePositions);  // tilf�ldige tal ml. 0 og 7, svarende til vector2 arrays'snes indexnumre, tilskrives til de tre positionsvariabler. 
        pigPosition = (int)Random.Range(0, numberOfPossiblePositions);
        sheepPosition = (int)Random.Range(0, numberOfPossiblePositions);
        while (cowPosition == pigPosition || pigPosition == sheepPosition || sheepPosition == cowPosition ||
            cowPosition == previousCowPosition && pigPosition == previousPigPosition && sheepPosition == previousSheepPosition) // hvis nogle af dyrene f�r det samme tal, eller alle positioner er de samme som 
                                                                                                                                // i foreg�ende sp�rgsm�l, tilskrives nye tilf�ldige v�rdier.
        {
            cowPosition = (int)Random.Range(0, numberOfPossiblePositions);
            pigPosition = (int)Random.Range(0, numberOfPossiblePositions);
            sheepPosition = (int)Random.Range(0, numberOfPossiblePositions);
        }

        currentConfig[0] = cowPosition;     // currentconfig arrayet opdateres med de nye positioner
        currentConfig[1] = pigPosition;
        currentConfig[2] = sheepPosition;

        //Debug.LogFormat("Ko: {0}. Gris: {1}. F�r: {2}", cowPosition, pigPosition, sheepPosition);

    }

    public void UpdatePrevious()    // gemmer de tidligere positioner inden de overskrives med nye positioner
    {
        previousCowPosition = cowPosition;
        previousPigPosition = pigPosition;
        previousSheepPosition = sheepPosition;
    }

    void PositionUpdater()          // Opdaterer dyrenes positioner ved at tage det tal de hver is�r f�r tilskrevet tilf�ldigt, og s�tte dem ind som index-numre i dyrenes egne vector2 arrays. 
    {
        cow.GetComponent<Transform>().position = possibleCowPositions[cowPosition]; // alle disse er vector2-v�rdier
        pig.GetComponent<Transform>().position = possiblePigPositions[pigPosition];
        sheep.GetComponent<Transform>().position = possibleSheepPositions[sheepPosition];
    }

    void SpriteUpdater()
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

        if (sheepPosition == 2 || sheepPosition == 6)
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

    void LayerUpdater()
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
}








