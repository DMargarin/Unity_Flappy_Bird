using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeMenuUi : MonoBehaviour
{
    public Image theme;
    
    void Start()
    {
        UpdateTheme();
    }

    public void NextTheme()
    {
        if (ThemeSelector.Instance != null)
        {
            ThemeSelector.Instance.NextTheme();
            UpdateTheme();
        }
    }

    public void PreviousTheme()
    {
        if (ThemeSelector.Instance != null)
        {
            ThemeSelector.Instance.PreviousTheme();
            UpdateTheme();
        }
    }

    void UpdateTheme()
    {
        if (ThemeSelector.Instance != null)
        {
            theme.sprite = ThemeSelector.Instance.GetCurrentTheme();
        }
    }
}
