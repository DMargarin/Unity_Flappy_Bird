using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public PipeMoveScript move;
    public float heightOffset = 10;
    private float requiredDistance = 12.5f;
    private float spawnRate = 2.5f;
    private float timer = 0;
    private float previousSpeed;
    private bool isInitialized = false;


    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {

        if (!isInitialized)
        {
            // Ждем первый кадр после спауна первой трубы
            if (PipeMoveScript.moveSpeed > 0)
            {
                previousSpeed = PipeMoveScript.moveSpeed;
                spawnRate = requiredDistance / PipeMoveScript.moveSpeed;
                isInitialized = true;
            }
            return;
        }

        if (Mathf.Abs(PipeMoveScript.moveSpeed - previousSpeed) > 0.0001f) //условие сработает и при увеличении и при уменьшении скорости
        {

            float t = timer / spawnRate;
            spawnRate = requiredDistance / PipeMoveScript.moveSpeed;
            timer = t * spawnRate;
            previousSpeed = PipeMoveScript.moveSpeed;

            if (timer >= spawnRate)
            {
                spawnPipe();
                timer = 0;
            }
        }

        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
