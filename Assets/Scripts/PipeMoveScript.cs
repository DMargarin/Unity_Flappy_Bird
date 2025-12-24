using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public LogicScript logic;
    
    public static float moveSpeed = 5f;
    private float deadZone = -35;
    public float boost = 0.5f;
    private static bool boosted1 = false;
    private static bool boosted2 = false;
    private static bool boosted3 = false;
    private static bool boosted4 = false;
    private static bool boosted5 = false;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;

         if (!boosted1 && logic.playerScore >= 10)
         {
            moveSpeed += boost;
            boosted1 = true;
         }

        if (!boosted2 && logic.playerScore >= 20)
        {
            moveSpeed += boost;
            boosted2 = true;
        }

        if (!boosted3 && logic.playerScore >= 40)
        {
            moveSpeed += boost;
            boosted3 = true;
        }

        if (!boosted4 && logic.playerScore >= 60)
        {
            moveSpeed += boost;
            boosted4 = true;
        }

        if (!boosted5 && logic.playerScore >= 80)
        {
            moveSpeed += boost;
            boosted5 = true;
        }

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }

    }

     void OnDestroy()
    {
        moveSpeed = 5f;
        boosted1 = false;
        boosted2 = false;
        boosted3 = false;
        boosted4 = false;
        boosted5 = false;
    }
}
