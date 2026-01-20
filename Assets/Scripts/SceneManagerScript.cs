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

    public void typeOfChallenge(int i)
    {
        switch (i) // Remembering of a challenge
        {
            case 1:
                Debug.Log("Ñhallenge 1");
                PlayerPrefs.SetString("challengeType", "challenge1");
                PlayerPrefs.Save();
                LoadScene("Difficulty");
            break;

            case 2:
                Debug.Log("Ñhallenge 2");
                PlayerPrefs.SetString("challengeType", "challenge2");
                PlayerPrefs.Save();
                LoadScene("Difficulty");
            break;

            case 3:
                Debug.Log("Ñhallenge 3");
                PlayerPrefs.SetString("challengeType", "challenge3");
                PlayerPrefs.Save();
                LoadScene("Difficulty");
            break;
        }
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
        PlayerPrefs.SetString("mode", "easy");
        PlayerPrefs.Save();
        LoadScene(sceneName);
    }

    public void MediumMode(string sceneName)
    {
        pipeMove.boost = 1f;
        Debug.Log("Medium");
        PlayerPrefs.SetString("mode", "medium");
        PlayerPrefs.Save();
        LoadScene(sceneName);
    }

    public void HardMode(string sceneName)
    {
        pipeMove.boost = 2f;
        Debug.Log("Hard");
        PlayerPrefs.SetString("mode", "hard");
        PlayerPrefs.Save();
        LoadScene(sceneName);
    }

}
