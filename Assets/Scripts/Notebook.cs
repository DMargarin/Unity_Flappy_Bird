/*using System.Collections;
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

    private int pipeCounter;

    // ПЕРЕМЕННУЮ public PipeMiddleScript middle МЫ УБРАЛИ, ТАК КАК ИЩЕМ ЕЁ ДИНАМИЧЕСКИ

    void Start()
    {
        // Теперь spawnPipe() возвращает ссылку на скрипт созданной трубы
        PipeMiddleScript newPipeMiddle = spawnPipe();
        showOrNot(newPipeMiddle);
    }

    void Update()
    {
        if (!isInitialized)
        {
            if (PipeMoveScript.moveSpeed > 0)
            {
                previousSpeed = PipeMoveScript.moveSpeed;
                spawnRate = requiredDistance / PipeMoveScript.moveSpeed;
                isInitialized = true;
            }
            return;
        }

        if (Mathf.Abs(PipeMoveScript.moveSpeed - previousSpeed) > 0.0001f)
        {
            float t = timer / spawnRate;
            spawnRate = requiredDistance / PipeMoveScript.moveSpeed;
            timer = t * spawnRate;
            previousSpeed = PipeMoveScript.moveSpeed;

            if (timer >= spawnRate)
            {
                PipeMiddleScript newPipeMiddle = spawnPipe();
                showOrNot(newPipeMiddle);
                timer = 0;
            }
        }

        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            PipeMiddleScript newPipeMiddle = spawnPipe();
            showOrNot(newPipeMiddle);
            timer = 0;
        }
    }

    // ИЗМЕНЕНО: Метод теперь возвращает PipeMiddleScript созданной трубы
    PipeMiddleScript spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        // 1. Создаем трубу на сцене и сохраняем ссылку на этот живой GameObject
        GameObject spawnedPipe = Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);

        // 2. Берем скрипт PipeMiddleScript именно с этой созданной трубы
        // Если скрипт висит на дочернем объекте префаба, используйте GetComponentInChildren
        PipeMiddleScript spawnedMiddle = spawnedPipe.GetComponent<PipeMiddleScript>();
        if (spawnedMiddle == null)
        {
            spawnedMiddle = spawnedPipe.GetComponentInChildren<PipeMiddleScript>();
        }

        return spawnedMiddle;
    }

    // ИЗМЕНЕНО: Метод теперь принимает ссылку на конкретную трубу
    public void showOrNot(PipeMiddleScript targetMiddle)
    {
        pipeCounter++;
        Debug.Log("pipeCounter: " + pipeCounter);

        // Проверяем, что деление без остатка, и что мы успешно нашли скрипт на трубе
        if (pipeCounter % 10 == 0 && targetMiddle != null)
        {
            targetMiddle.showCoin(); // Вызываем метод у ЖИВОЙ трубы на сцене
            Debug.Log("The coin was shown!");
        }
    }
}*/
