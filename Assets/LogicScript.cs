using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Game Scene Script
public class LogicScript : MonoBehaviour
{
    //keeps track of player's score
    public int playerScore;

    //keeps track of the highest score
    public int highScore;

    //references the score text object within the canvas on the game scene
    public Text scoreText;

    //references the high score text object within the canvas on the game scene
    public Text highScoreText;

    /* references the audio object that's created on this logic script
     * check the logic manager in inspector on unity editor
     */
    public AudioSource scoreAudio;

    //references the game over screen object within the canvas on the game scene
    public GameObject gameOverScreen;

    void Start()
    {
        //will load the high score as soon as the game starts
        loadScore();
    }

    /* ContextMenu = adds menu option to LogicScript within the editor (inspector view)
     * Will add to the player's score when called.
     * Will play a sound when score is added.
     */
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        scoreAudio.Play();
    }

    /*
     * restarts the game if called
     * Loads the title scene
     * unloads the game scene
     * both scenes should not be present at the same time
     */
    public void restartGame()
    {
        SceneManager.LoadScene(0);
        SceneManager.UnloadScene(1);
    }

    //will load the highest score if present
    public void loadScore()
    {
        //checks if data has been previously stored --> check line 96: PlayerPrefs.Save();
        if (PlayerPrefs.HasKey("highSchore") && PlayerPrefs.HasKey("highScoreText")) //PlayerPrefs.HasKey("variableName") --> checks for saved data
        {
            highScore = PlayerPrefs.GetInt("highScore");
            highScoreText.text = PlayerPrefs.GetString("highScoreText");
        }
        
        else //default values if previous data is not available.
        {
            //sets high score to 0
            highScore = PlayerPrefs.GetInt("highScore", 0); 
            
            //PlayerPrefs.GetType("variableName", value) gets the "variableName" with a specific value
            
            //will show High Score: 0 
            highScoreText.text = PlayerPrefs.GetString("highScoreText", "High Score: "+highScore);
        }
    }

    //updates the high score 
    public void updateScore()
    {
        if(playerScore>highScore)
        {
            /* PlayerPrefs.SetType("variableName", value) sets the "variableName" with a specific value
             in this case we are saving the high score into Player prefs along with the high score text */
            
            highScore = playerScore;
            PlayerPrefs.SetInt("highScore", highScore); 

            highScoreText.text = "High Score: " + highScore.ToString();
            PlayerPrefs.SetString("highScoreText", highScoreText.text.ToString());

            PlayerPrefs.Save(); //saves the "variableName" with the specific value

            Debug.Log(PlayerPrefs.GetInt("highSchore"));
            Debug.Log(PlayerPrefs.GetString("highSchoreText"));

        }
    }

    /* Updates the high score when the ends
     * Shows the game over screen when the game ends */
    public void gameOver()
    {
        updateScore();
        gameOverScreen.SetActive(true);
    }

}
