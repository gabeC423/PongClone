using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Button UnlimitedScoreButton, FirstToTenButton, FirstToFiveButton;
    // Start is called before the first frame update
    void Start()
    {
        UnlimitedScoreButton.onClick.AddListener(() => SelectMode("Unlimited"));
        FirstToTenButton.onClick.AddListener(() => SelectMode("TEN"));
        FirstToFiveButton.onClick.AddListener(() => SelectMode("FIVE"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Displays the mode selection screen.
    public void StartModeScene()
    {
        SceneManager.LoadScene("ModeSelect");
    }

    // Sets the game mode in BallScript, Unlimited uses default null instance of game.
    public void SelectMode(String mode)
    {
        if (mode == "Unlimited")
        {
            SceneManager.LoadScene("GameScene");
        }
        else if (mode == "TEN")
        {
            GameValues.maxScore = 10;
            SceneManager.LoadScene("GameScene");
            Debug.Log("MODE: 10");
        }
        else if (mode == "FIVE")
        {
            GameValues.maxScore = 5;
            SceneManager.LoadScene("GameScene");
            Debug.Log("MODE: 5");
        }
    }

    // Function to exit the game when exit button is clicked.
    public void ExitGame()
    {
        Debug.Log("Quit");
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
