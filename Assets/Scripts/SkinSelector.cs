using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinSelector : MonoBehaviour
{

    public string[] skinNames;
    public Sprite[] skins;
    public int[] skinPrices;
    private int currentName;
    private int currentSkin;
    private int currentPrice;
    
    public static SkinSelector Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            currentName = PlayerPrefs.GetInt("numberOfSkinName", 0);
            currentSkin = PlayerPrefs.GetInt("numberOfSkin", 0);
            currentPrice = PlayerPrefs.GetInt("numberOfSkinPrice", 0);

            PlayerPrefs.SetInt("skin_Basic pig", 1);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public string GetCurrentName()
    {
        return skinNames[currentName];
    }

    public Sprite GetCurrentSkin()
    {
        return skins[currentSkin];
    }

    public int GetCurrentPrice()
    {
        return skinPrices[currentPrice];
    }

    public void NextSkin()
    {
        if (currentSkin < skins.Length - 1)
        {
            currentName++;
            currentSkin++;
            currentPrice++;

            Save();

            SkinAssignments();
        }  
    }

    public void PreviousSkin()
    {
        if (currentSkin > 0)
        {
            currentName--;
            currentSkin--;
            currentPrice--;

            Save();

            SkinAssignments();
        }
    }

    public void SkinAssignments()
    {
        string skinNameArrayElement = "skin_" + GetCurrentName(); //get a product's name

        /*if (PlayerPrefs.GetInt(skinNameArrayElement, 0) != 1)
        {
            PlayerPrefs.SetInt(skinNameArrayElement, 0);
        }*/

        int a = PlayerPrefs.GetInt(skinNameArrayElement, 0); //just for the console
        Debug.Log(skinNameArrayElement + " statement: " + a);

        MainTitleScreen.Instance.StateOfProductUpdate(skinNameArrayElement, 2);
    }

    public void Save()
    {
        PlayerPrefs.SetInt("numberOfSkinName", currentName);
        PlayerPrefs.SetInt("numberOfSkin", currentSkin);
        PlayerPrefs.SetInt("numberOfSkinPrice", currentPrice);
        PlayerPrefs.Save();
    }
}
