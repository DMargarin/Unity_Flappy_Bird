using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThemeSelector : MonoBehaviour
{

    public Sprite[] themes;
    public string[] themeNames;
    public int [] themePrices;
    public int currentName;
    private int currentTheme = 0;
    private int currentPrice;
    public static ThemeSelector Instance;

    /*public GameObject price1;
    public GameObject price2;*/

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            currentName = PlayerPrefs.GetInt("numberOfThemeName", 0);
            currentTheme = PlayerPrefs.GetInt("numberOfTheme", 0);
            currentPrice = PlayerPrefs.GetInt("numberOfThemePrice", 0);

            PlayerPrefs.SetInt("theme_Basic pipe", 1);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public string GetCurrentName() 
    {
        /*Debug.Log("Theme Name: " + themeNames[currentName]);*/
        return themeNames[currentName];
    }

    public Sprite GetCurrentTheme()
    {
        /*Debug.Log("Theme: " + themes[currentTheme]);*/
        return themes[currentTheme];
    }

    public int GetCurrentPrice()
    {
        /*Debug.Log("Theme Price: " + themePrices[currentPrice]);*/
        return themePrices[currentPrice];
    }

    public void NextTheme()
    {

        if (currentName < themeNames.Length - 1)
        {
            currentName++;
            currentTheme++;
            currentPrice++;

            Save();

            ThemeAssignments();
        }
    }

    public void PreviousTheme()
    {
        
        if(currentName > 0)
        {
            currentName--;
            currentTheme--;
            currentPrice--;

            Save();

            ThemeAssignments();
        }
    }

    public void ThemeAssignments()
    {
        string themeNameArrayElement = "theme_" + GetCurrentName(); //get a product's name

        /*if (PlayerPrefs.GetInt(themeNameArrayElement, 0) != 1)
        {
            PlayerPrefs.SetInt(themeNameArrayElement, 0);
        }*/

        int a = PlayerPrefs.GetInt(themeNameArrayElement, 0); //just for the console
        Debug.Log(themeNameArrayElement + " statement: " + a);

        MainTitleScreen.Instance.StateOfProductUpdate(themeNameArrayElement, 1);
    }

    public void Save()
    {
        PlayerPrefs.SetInt("numberOfThemeName", currentName);
        PlayerPrefs.SetInt("numberOfTheme", currentTheme);
        PlayerPrefs.SetInt("numberOfThemePrice", currentPrice);
        PlayerPrefs.Save();
    }

}
