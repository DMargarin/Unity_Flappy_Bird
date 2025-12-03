using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{

    public PipeMoveScript pipeMove;
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void FreeMode(string sceneName)
    {
        pipeMove.boost = 0f;
        Debug.Log("Easy");
        LoadScene(sceneName);
    }

    public void EasyMode(string sceneName)
    {
        pipeMove.boost = 0.5f;
        Debug.Log("Easy");
        LoadScene(sceneName);
    }

    public void MediumMode(string sceneName)
    {
        pipeMove.boost = 1f;
        Debug.Log("Medium");
        LoadScene(sceneName);
    }

    public void HardMode(string sceneName)
    {
        pipeMove.boost = 2f;
        Debug.Log("Hard");
        LoadScene(sceneName);
    }

}
