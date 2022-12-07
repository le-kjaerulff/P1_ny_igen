using UnityEngine;
using System.IO;

public class TextScript : MonoBehaviour
{
    private GameManager _gameManager;
    void CreateText()
    {   
        // Path of file
        string path = Application.dataPath + "/Log.txt";
        // Create file if ! exits
        if(!File.Exists(path))
        {
            File.WriteAllText(path, "Results log \n\n");
        }
        // Content of file
        string content = "Results date: " + System.DateTime.Now + "\n";
        string score = "Score: " + _gameManager.playerScore;
        // Add text to file
        File.AppendAllText(path, content + score);
    }
    // Start is called before the first frame update
    void Start()
    {
        // Initialization
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        CreateText();
        
    }
 }
