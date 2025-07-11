using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    public int counter;
    public Text counterText;
    public GameObject gameOScreen;
    public bool isGameOver = false;

    public Text highScoreText;
    public Text newHighScoreText;

    void Start()
    {
        counter = 0; // Start of a new game.

        // Load the saved record from PlayerPrefs, default is 0.
        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);

        // Update the UI.
        counterText.text = counter.ToString();
        highScoreText.text = "High Score: " + savedHighScore.ToString();
        highScoreText.gameObject.SetActive(true);

        if (newHighScoreText != null)
            newHighScoreText.gameObject.SetActive(false);

        isGameOver = false;
        gameOScreen.SetActive(false); // Hide the GameOver screen at the start.
    }

    public void addCounter()
    {
        if (isGameOver) return;

        counter++;
        counterText.text = counter.ToString();
    }

    public void restartGamePlay()
    {
        // Load a new game, reload the same scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        isGameOver = true;
        gameOScreen.SetActive(true);

        int highScore = PlayerPrefs.GetInt("HighScore", 0);
       
        // Check if current score beats high score.
        if (counter > highScore)
        {   // Save new high score
            PlayerPrefs.SetInt("HighScore", counter);
            PlayerPrefs.Save();
            // Show new high score message.
            if (newHighScoreText != null)
            {
                newHighScoreText.text = "🎉 New High Score: " + counter.ToString();
                newHighScoreText.gameObject.SetActive(true);
            }
        }
        else
        {   // Hide new high score message if not beaten.
            if (newHighScoreText != null)
                newHighScoreText.gameObject.SetActive(false);
        }
        // Display current high score.
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        highScoreText.gameObject.SetActive(true);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Mainmenu");

    }


}
