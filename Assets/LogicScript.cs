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
    public AudioSource pickCoinSound;
    public AudioSource pickCoinSoundIfTen;
    public AudioSource soundIfDeath;


    private int highScore = 0;
    public GameObject gameOverScreen;
    private bool deleted = false;
    //private float timer = 0;
    //public float soundPlays = 0f;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        score.text = playerScore.ToString();
        
        if (playerScore % 10 == 0 && playerScore != 0)
        {
            pickCoinSoundIfTen.Play();
        }

    }

    public void flapSound()
    {
        pickCoinSound.Play();
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);

        soundIfDeath.Play();

        urScore.text = "Your score: " + playerScore.ToString();

        highScore = PlayerPrefs.GetInt("highScore", 0);

        if (playerScore > highScore && deleted == false)
        {
            PlayerPrefs.SetInt("highScore", playerScore);
        }
       

        bestScore.text = "Best Score: " + highScore.ToString();

        
        
    }

    public void killBestScore()
    {
        PlayerPrefs.DeleteKey("highScore");
        PlayerPrefs.Save();
        deleted = true;
    }
}
