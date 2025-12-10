using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    public Rigidbody2D myRigidbody;
    public LogicScript logic;
    public AudioSource birdFlapSound;
    public GameObject mark1;
    public GameObject mark2;
    public GameObject mark3;

    public float flapStrength;
    public bool IsAlive = true;
    private bool isGameOverScreenOn = false;
    private bool isVictoryScreenOn = false;
    private string mode;
    private bool markOneState;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        mode = PlayerPrefs.GetString("mode", "challenge");
        Debug.Log("Mode: " + mode);
        mark1 = GameObject.FindGameObjectWithTag("mark1");
        mark2 = GameObject.FindGameObjectWithTag("mark2");
        mark3 = GameObject.FindGameObjectWithTag("mark3");

        markOneState = System.Convert.ToBoolean(PlayerPrefs.GetString("mark1", "false"));
        mark1.SetActive(markOneState);
        mark2.SetActive(true);
        mark3.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && IsAlive == true && isVictoryScreenOn == false)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            logic.flapSound();
        }
        
        if (transform.position.y > 14 ||  transform.position.y < -14)
        {
            birdDeath();
        }

        if (IsAlive == false) //if bird is dead we can restart with "space"
        {
            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                logic.restartGame();
            }
        }
        
        if(logic.playerScore == 100 && mode != "free") // for challenges
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
        if (isVictoryScreenOn == false)
        {
            if(mode == "easy")
            {
                PlayerPrefs.SetString("mark", "true");
                PlayerPrefs.Save();
            }
            logic.victoryMenu();
            isVictoryScreenOn = true;
        }
        
    }
}
