using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTitleScreen : MonoBehaviour
{
    public TMPro.TMP_Text money;
    public int amount;
    public static MainTitleScreen Instance;

    public GameObject price1;
    public GameObject price2;

    public Image buttonImage;

    public Sprite state1;
    public Sprite state2;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        /*PlayerPrefs.SetInt("amountOfMoney", 9999);*/
        money.text = PlayerPrefs.GetInt("amountOfMoney", amount).ToString();

        int a = PlayerPrefs.GetInt("soundButton", 0);
        switch (a)
        {
            case 1:
                buttonImage.sprite = state1;
                AudioListener.volume = 1f;
                break;
            case 2:
                buttonImage.sprite = state2;
                AudioListener.volume = 0f;
                break;
        }
        
    }

    public void addMoney(int moneyToAdd)
    {
        amount = PlayerPrefs.GetInt("amountOfMoney", amount);
        amount += moneyToAdd;

        Debug.Log("amount: " + amount);

        Save(amount);
        money.text = amount.ToString();
        UpdateMoney();
    }

    public void price1Button()
    {
        /*price1.interactable = false;*/
        int subtrahend1 = ThemeSelector.Instance.GetCurrentPrice();
        string themeNameArrayElement = "theme_" + ThemeSelector.Instance.GetCurrentName();
        removeMoney(subtrahend1, themeNameArrayElement, 1);

        amount = PlayerPrefs.GetInt("amountOfMoney", amount);
        if (subtrahend1 <= amount)
        {
            price1.SetActive(false);
        }
    }

    public void price2Button()
    {
        int subtrahend2 = SkinSelector.Instance.GetCurrentPrice();
        string skinNameArrayElement = "skin_" + SkinSelector.Instance.GetCurrentName();
        removeMoney(subtrahend2, skinNameArrayElement, 2);

        amount = PlayerPrefs.GetInt("amountOfMoney", amount);
        if (subtrahend2 <= amount)
        {
            price2.SetActive(false);
        }
    }

    public void removeMoney(int subtrahend, string productNameArrayElement, int buttonNumber) //solve the problem
    {
        amount = PlayerPrefs.GetInt("amountOfMoney", amount);

        if (subtrahend <= amount)
        {
            amount -= subtrahend;

            Save(amount);
            money.text = amount.ToString();
            UpdateMoney();

            PlayerPrefs.SetInt(productNameArrayElement, 1);
            StateOfProductUpdate(productNameArrayElement, buttonNumber);
        }

    }

    public void StateOfProductUpdate(string productName, int buttonNumber) //product was bought -> turn off
    {
        switch (buttonNumber)
        {
            case 1:
                if (PlayerPrefs.GetInt(productName, 0) == 0)
                {
                    price1.SetActive(true);
                }
                else
                {
                    price1.SetActive(false);
                }
            break;

            case 2:
                if (PlayerPrefs.GetInt(productName, 0) == 0)
                {
                    price2.SetActive(true);
                }
                else
                {
                    price2.SetActive(false);
                }
            break;
        }
    }

    public void Save(int amount)
    {
        PlayerPrefs.SetInt("amountOfMoney", amount);
        PlayerPrefs.Save();
    }

    void UpdateMoney()
    {
        money.text = PlayerPrefs.GetInt("amountOfMoney", amount).ToString();
    }

    public void killMoney()
    {
        PlayerPrefs.DeleteKey("amountOfMoney");

        /*PlayerPrefs.DeleteKey("numberOfThemeName");
        PlayerPrefs.DeleteKey("numberOfTheme");
        PlayerPrefs.DeleteKey("numberOfThemePrice");
        PlayerPrefs.DeleteKey("numberOfSkinName");
        PlayerPrefs.DeleteKey("numberOfSkin");
        PlayerPrefs.DeleteKey("numberOfSkinPrice");
        PlayerPrefs.DeleteKey("numberOfName");
        PlayerPrefs.DeleteKey("numberOfPrice");*/
        PlayerPrefs.DeleteAll();

        PlayerPrefs.Save();
    }

    public void adButton()
    {
        /*addMoney(10);*/
    }

    public void soundOnOff()
    {
        if (AudioListener.volume == 0f)
        {
            AudioListener.volume = 1f;
            buttonImage.sprite = state1;
            PlayerPrefs.SetInt("soundButton", 1);
            PlayerPrefs.Save();
        }
        else
        {
            AudioListener.volume = 0f;
            buttonImage.sprite = state2;
            PlayerPrefs.SetInt("soundButton", 2);
            PlayerPrefs.Save();
        }
    }
}

