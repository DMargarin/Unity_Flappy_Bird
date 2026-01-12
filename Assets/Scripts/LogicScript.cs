using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public TMPro.TMP_Text score;
    public TMPro.TMP_Text urScore;
    public TMPro.TMP_Text bestScore;
    public AudioSource pickCoinSound;
    public AudioSource pickCoinSoundIfTen;
    public AudioSource soundIfDeath;


    private int highScore = 0;
    public GameObject gameOverScreen;
    public GameObject victoryScreen;
    private bool deleted = false;
    public bool switcher1 = false;
    public bool switcher2 = false;
    public bool switcher3 = false;
    


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

    public void victoryMenu()
    {
        victoryScreen.SetActive(true);

        //PlayerPrefs.SetInt("mark1", 1);
        //PlayerPrefs.Save();

        //have to be added a sound effect
    }

    public void killBestScore()
    {
        PlayerPrefs.DeleteKey("highScore");
        PlayerPrefs.Save();
        deleted = true;
    }
}
