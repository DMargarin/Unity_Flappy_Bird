using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    public Rigidbody2D myRigidbody;
    public LogicScript logic;
    public AudioSource birdFlapSound;
    

    public float flapStrength;
    public bool IsAlive = true;
    private bool isGameOverScreenOn = false;
    private bool isVictoryScreenOn = false;
    private string mode;
    

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        mode = PlayerPrefs.GetString("mode", "challenge");
        Debug.Log("Mode: " + mode);

        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) == true || Input.GetMouseButtonDown(0) == true) && IsAlive == true && isVictoryScreenOn == false)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            logic.flapSound();
        }
        
        if (transform.position.y > 14 ||  transform.position.y < -14)
        {
            birdDeath();
        }

        if (IsAlive == false && isVictoryScreenOn == false) //Restarting with space
        {
            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                logic.restartGame();
            }
        }
        
        if(logic.playerScore == 100 && mode != "free") // Victory screen for challenges
        {
            victory(mode);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        birdDeath();
    }

    public void birdDeath()
    {
        if (isGameOverScreenOn == false && isVictoryScreenOn == false)
        {
            logic.gameOver();
            IsAlive = false;
            isGameOverScreenOn = true;
        }

    }

    public void victory(string mode)
    {
        IsAlive = false;

        string typeOfChallenge = PlayerPrefs.GetString("challengeType", "type");

        switch (typeOfChallenge)
        {
            case "challenge1":
                if (isVictoryScreenOn == false)
                {
                    if (mode == "easy")
                    {
                        PlayerPrefs.SetInt("mark1", 1);
                        PlayerPrefs.Save();
                    }
                    else if (mode == "medium")
                    {
                        PlayerPrefs.SetInt("mark2", 1);
                        PlayerPrefs.Save();
                    }
                    else if (mode == "hard")
                    {
                        PlayerPrefs.SetInt("mark3", 1);
                        PlayerPrefs.Save();
                    }
                    logic.victoryMenu();
                    isVictoryScreenOn = true;
                }
            break;

            case "challenge2":
                if (isVictoryScreenOn == false)
                {
                    if (mode == "easy")
                    {
                        PlayerPrefs.SetInt("mark4", 1);
                        PlayerPrefs.Save();
                    }
                    else if (mode == "medium")
                    {
                        PlayerPrefs.SetInt("mark5", 1);
                        PlayerPrefs.Save();
                    }
                    else if (mode == "hard")
                    {
                        PlayerPrefs.SetInt("mark6", 1);
                        PlayerPrefs.Save();
                    }
                    logic.victoryMenu();
                    isVictoryScreenOn = true;
                }
            break;

            case "challenge3":
                if (isVictoryScreenOn == false)
                {
                    if (mode == "easy")
                    {
                        PlayerPrefs.SetInt("mark7", 1);
                        PlayerPrefs.Save();
                    }
                    else if (mode == "medium")
                    {
                        PlayerPrefs.SetInt("mark8", 1);
                        PlayerPrefs.Save();
                    }
                    else if (mode == "hard")
                    {
                        PlayerPrefs.SetInt("mark9", 1);
                        PlayerPrefs.Save();
                    }
                    logic.victoryMenu();
                    isVictoryScreenOn = true;
                }
            break;
        }
    }
}
