using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{

    public PipeMoveScript pipeMove;

    //public bool isFreeMode = false;
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void FreeMode(string sceneName)
    {
        pipeMove.boost = 0f;
        Debug.Log("FreeMode");
        PlayerPrefs.SetString("mode", "free");
        PlayerPrefs.Save();
        LoadScene(sceneName);
    }

    public void EasyMode(string sceneName)
    {
        pipeMove.boost = 0.5f;
        Debug.Log("Easy");
        PlayerPrefs.SetString("mode", "challenge");
        PlayerPrefs.Save();
        LoadScene(sceneName);
    }

    public void MediumMode(string sceneName)
    {
        pipeMove.boost = 1f;
        Debug.Log("Medium");
        PlayerPrefs.SetString("mode", "challenge");
        PlayerPrefs.Save();
        LoadScene(sceneName);
    }

    public void HardMode(string sceneName)
    {
        pipeMove.boost = 2f;
        Debug.Log("Hard");
        PlayerPrefs.SetString("mode", "challenge");
        PlayerPrefs.Save();
        LoadScene(sceneName);
    }

}
