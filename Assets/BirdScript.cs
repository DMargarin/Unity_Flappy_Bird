using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource birdFlapSound;
    private bool isGameOverScreenOn = false;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            logic.flapSound();
        }
        
        if (transform.position.y > 14 ||  transform.position.y < -14)
        {
            birdDeath();
        }

        if (birdIsAlive == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                Debug.Log("I'm working");
                logic.restartGame();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        birdDeath();
    }

    public void birdDeath()
    {
        if (isGameOverScreenOn == false)
        {
            logic.gameOver();
            birdIsAlive = false;
            isGameOverScreenOn = true;
        }

    }
}
