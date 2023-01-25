using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    // Private Variables
    private Button button;
    private GameManager gameManager;

    // Public Variables
    public int difficulty;
    
    // Start is called before the first frame update
    // Instantiate the buttons and game manager for starting the game
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Lets the player know what button they clicked on the bottom left of the screen and also starts the game based on the difficulty they chose
    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked.");
        gameManager.StartGame(difficulty);
    }
}
