using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class finalScore : MonoBehaviour
{
    GameManager GameManager;
    public Text HStext;

    public int score;
    public GameObject Panel;
    // Start is called before the first frame update
    void Awake()
    {
        GameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();


    }
    private void Start()
    {
        HStext.text = "HIGHSCORE:" + PlayerPrefs.GetInt("highscore");

       
    }

    // Update is called once per frame
    void Update()
    {

    }
    
        

    public void FinalScore() //Aktiver funktion ved button press (inspector)
    {
        if (Panel != null)
        {
            if (GameManager.playerScore>PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", GameManager.playerScore);
            }
           
            Panel.SetActive(true);
            score = GameManager.playerScore;
            Panel.GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();
        }
        
    }
    
}


        
        // Sørg for at panel bliver aktivt

        // Updater panel text med score fra GameManager
        // score = gamemanager.getscore()
        // GetComponent<Text>
        // Text = "din score er" + score;


