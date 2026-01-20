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
        score.text = playerScore.ToString();// Upper Left Number on the Screen
        
        if (playerScore % 10 == 0 && playerScore != 0)
        {
            pickCoinSoundIfTen.Play();
        }

        /*______________________________________________*/
        
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

        //Score counting


        highScore = PlayerPrefs.GetInt("highScore", 0);

        if (highScore <= playerScore && deleted == false)
        {
            PlayerPrefs.SetInt("highScore", playerScore);
            PlayerPrefs.Save();
            urScore.text = "Your score: " + playerScore.ToString();
            bestScore.text = "Best score: " + PlayerPrefs.GetInt("highscore", playerScore);

            Debug.Log("The first condition worked");
            Debug.Log("Best Score: " + bestScore.text);
        }
        else
        {
            urScore.text = "Your score: " + playerScore.ToString();
            bestScore.text = "Best score: " + highScore.ToString();

            Debug.Log("The second condition worked");

            //Debug.Log("Your Score: " + playerScore);
            //Debug.Log("Best Score: " + highScore);
        } 
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
        Debug.Log("Data was deleted");
    }
}
