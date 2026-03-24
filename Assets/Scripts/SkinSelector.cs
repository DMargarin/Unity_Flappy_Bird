using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinSelector : MonoBehaviour
{
    
    public Sprite[] skins;
    public int currentSkin = 0;
    public static SkinSelector Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            currentSkin = PlayerPrefs.GetInt("numberOfSkin", 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Sprite GetCurrentSkin()
    {
        return skins[currentSkin];
    }

    public void NextSkin()
    {
        if (currentSkin < skins.Length - 1)
        {
            currentSkin++;

            Save();
        }  
    }

    public void PreviousSkin()
    {
        if (currentSkin > 0)
        {
            currentSkin--;

            Save();
        }
    }

    public void Save()
    {
        PlayerPrefs.SetInt("numberOfSkin", currentSkin);
        PlayerPrefs.Save();
    }
}
