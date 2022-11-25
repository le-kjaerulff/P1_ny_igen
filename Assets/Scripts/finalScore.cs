using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalScore : MonoBehaviour
{
    GameManager GameManager;

    public int score;
    public GameObject Panel;
    // Start is called before the first frame update
    void Awake()
    {
        GameManager = GameObject.Find("score").GetComponent<GameManager>();


    }

    // Update is called once per frame
    void Update()
    {

    }
    
        

    public void FinalScore() //Aktiver funktion ved button press (inspector)
    {
        if (Panel != null)
        {
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


