using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Button[] buttons;

    public Button prize1;
    public Button prize2;
    public Button prize3;

    public TMPro.TMP_Text task;

    private string typeOfChallenge;


    // Start is called before the first frame update
    void Start()
    {
        
        stateOfButtons();

        // Проходим циклом по всем кнопкам
        for (int i = 0; i < buttons.Length; i++)
        {
            Button currentButton = buttons[i];

            // Подписываем каждую кнопку на один и тот же универсальный метод
            currentButton.onClick.AddListener(() => OnAnyButtonClicked(currentButton));
        }

        typeOfChallenge = PlayerPrefs.GetString("challengeType", "type"); //marks' system

        MarksSwitchingOff();

        switch (typeOfChallenge) // wk of challenge did we get?
        {
            case "challenge1":
                task.text = 
                    "In this challenge you need to watch for pig's speed, it will increase during playing the game.\r\n" +
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

    
   public void MarksSwitchingOff() //turning off the marks (probably could do the same via inspector)
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

   public void deleteAllMarks() //deleting all the memory
   {
        PlayerPrefs.DeleteKey("mark1");
        PlayerPrefs.DeleteKey("mark2");
        PlayerPrefs.DeleteKey("mark3");
        /*PlayerPrefs.DeleteKey("mark4");
        PlayerPrefs.DeleteKey("mark5");
        PlayerPrefs.DeleteKey("mark6");
        PlayerPrefs.DeleteKey("mark7");
        PlayerPrefs.DeleteKey("mark8");
        PlayerPrefs.DeleteKey("mark9");*/
        PlayerPrefs.DeleteKey("prize1");
        PlayerPrefs.DeleteKey("prize2");
        PlayerPrefs.DeleteKey("prize3");
        PlayerPrefs.DeleteKey("prizeCounter1");
        PlayerPrefs.DeleteKey("prizeCounter2");
        PlayerPrefs.DeleteKey("prizeCounter3");
        /*PlayerPrefs.SetInt("prize1", 0);
        PlayerPrefs.SetInt("prize2", 0);
        PlayerPrefs.SetInt("prize3", 0);
        PlayerPrefs.SetInt("prizeCounter1", 0);
        PlayerPrefs.SetInt("prizeCounter2", 0);
        PlayerPrefs.SetInt("prizeCounter3", 0);*/
        PlayerPrefs.Save();
   }

    // Универсальный метод, который знает, какая именно кнопка была нажата
    void OnAnyButtonClicked(Button clickedButton)
    {
        Debug.Log($"Нажата кнопка: {clickedButton.name}");

        clickedButton.interactable = false;

        PlayerPrefs.SetInt(clickedButton.name, 0);
        PlayerPrefs.Save();

        switch (clickedButton.name)
        {
            case "prize1":
                MainTitleScreen.Instance.addMoney(10);
                break;

            case "prize2":
                MainTitleScreen.Instance.addMoney(25);
                break;

            case "prize3":
                MainTitleScreen.Instance.addMoney(50);
                break;

        }


        /*Debug.Log("This button is:" + clickedButton.name);
        bool p1 = PlayerPrefs.GetInt("prize1", 0) == 1;
        bool p2 = PlayerPrefs.GetInt("prize2", 0) == 1;
        bool p3 = PlayerPrefs.GetInt("prize3", 0) == 1;
        Debug.Log("prize1 is: " + p1);
        Debug.Log("prize2 is: " + p2);
        Debug.Log("prize3 is: " + p3);*/
    }

    void stateOfButtons() //checking out should we turn on/off a button
    {
        Debug.Log("Buttons' Defenition!");
        bool p1 = PlayerPrefs.GetInt("prize1", 0) == 1;
        prize1.interactable = p1;
        bool p2 = PlayerPrefs.GetInt("prize2", 0) == 1;
        prize2.interactable = p2;
        bool p3 = PlayerPrefs.GetInt("prize3", 0) == 1;
        /*Debug.Log(p3);*/
        prize3.interactable = p3;
    }
}