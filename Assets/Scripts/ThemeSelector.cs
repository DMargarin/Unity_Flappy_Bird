using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeSelector : MonoBehaviour
{
    public Sprite[] themes;
    public int currentTheme = 0;
    public static ThemeSelector Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            currentTheme = PlayerPrefs.GetInt("numberOfTheme", 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Sprite GetCurrentTheme()
    {
        return themes[currentTheme];
    }

    public void NextTheme()
    {
        if (currentTheme < themes.Length - 1)
        {
            currentTheme++;

            Save();
        }
    }

    public void PreviousTheme()
    {
        if (currentTheme > 0)
        {
            currentTheme--;

            Save();
        }
    }

    public void Save()
    {
        PlayerPrefs.SetInt("numberOfTheme", currentTheme);
        PlayerPrefs.Save();
    }
}
