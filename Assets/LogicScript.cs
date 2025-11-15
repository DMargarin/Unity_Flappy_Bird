using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text score;
    public Text urScore;
    public Text bestScore;
    private int highScore = 0;
    public GameObject gameOverScreen;
    private bool deleted = false;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        score.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);

        urScore.text = "Your score: " + playerScore.ToString();

        highScore = PlayerPrefs.GetInt("highScore", 0);

        //Debug.Log(deleted);

        if (playerScore > highScore && deleted == false)
        {
            PlayerPrefs.SetInt("highScore", playerScore);
        }
       

        bestScore.text = "Best Score: " + highScore.ToString();

        

        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            restartGame();
        }
    }

    public void killBestScore()
    {
        PlayerPrefs.DeleteKey("highScore");
        PlayerPrefs.Save();
        deleted = true;
    }
}
