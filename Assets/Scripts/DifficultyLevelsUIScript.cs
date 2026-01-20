using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyLevelsUIScript : MonoBehaviour
{
    public GameObject mark1;
    public GameObject mark2;
    public GameObject mark3;
    public GameObject mark4;
    public GameObject mark5;
    public GameObject mark6;
    public GameObject mark7;
    public GameObject mark8;
    public GameObject mark9;
    public TMPro.TMP_Text task;

    private string typeOfChallenge;


    // Start is called before the first frame update
    void Start()
    {

        typeOfChallenge = PlayerPrefs.GetString("challengeType", "type");

        MarksSwitchingOff();

        switch (typeOfChallenge)
        {
            case "challenge1":
                task.text = 
                    "In this challenge you need to watch for bird's speed, it will increase during playing the game.\r\n" +
                    "As soon as you get 100 points you win.\r\n" +
                    "Good luck!";

                bool markOneState = PlayerPrefs.GetInt("mark1", 0) == 1;
                bool markTwoState = PlayerPrefs.GetInt("mark2", 0) == 1;
                bool markThreeState = PlayerPrefs.GetInt("mark3", 0) == 1;

                mark1.SetActive(markOneState);
                mark2.SetActive(markTwoState);
                mark3.SetActive(markThreeState);
            break;

            case "challenge2":
                task.text =
                    "In this challenge you need to watch for sequences of colors and choose the right way.\r\n" +
                    "As soon as you get 100 points you win.\r\n" +
                    "Good luck!";

                bool markFourState = PlayerPrefs.GetInt("mark4", 0) == 1;
                bool markFiveState = PlayerPrefs.GetInt("mark5", 0) == 1;
                bool markSixState = PlayerPrefs.GetInt("mark6", 0) == 1;

                mark4.SetActive(markFourState);
                mark5.SetActive(markFiveState);
                mark6.SetActive(markSixState);
            break;

            case "challenge3":
                task.text =
                    "In this challenge you need to watch for mathematical examples and choose the way with the right answer.\r\n" +
                    "As soon as you get 100 points you win.\r\n" +
                    "Good luck!";

                bool markSevenState = PlayerPrefs.GetInt("mark7", 0) == 1;
                bool markEightState = PlayerPrefs.GetInt("mark8", 0) == 1;
                bool markNineState = PlayerPrefs.GetInt("mark9", 0) == 1;

                mark7.SetActive(markSevenState);
                mark8.SetActive(markEightState);
                mark9.SetActive(markNineState);
            break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
   public void MarksSwitchingOff()
    {
        mark1.SetActive(false);
        mark2.SetActive(false);
        mark3.SetActive(false);
        mark4.SetActive(false);
        mark5.SetActive(false);
        mark6.SetActive(false);
        mark7.SetActive(false);
        mark8.SetActive(false);
        mark9.SetActive(false);
    }

   public void deleteAllMarks() {
        
        PlayerPrefs.DeleteKey("mark1");
        PlayerPrefs.DeleteKey("mark2");
        PlayerPrefs.DeleteKey("mark3");
        PlayerPrefs.DeleteKey("mark4");
        PlayerPrefs.DeleteKey("mark5");
        PlayerPrefs.DeleteKey("mark6");
        PlayerPrefs.DeleteKey("mark7");
        PlayerPrefs.DeleteKey("mark8");
        PlayerPrefs.DeleteKey("mark9");
        PlayerPrefs.Save();
   }

}
