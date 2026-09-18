using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThemeMenuUi : MonoBehaviour
{
    public TMPro.TMP_Text themeName;
    public Image theme;
    public TMPro.TMP_Text price;
    
    void Start()
    {
        UpdateTheme();
        ThemeSelector.Instance.ThemeAssignments();
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
            themeName.text = ThemeSelector.Instance.GetCurrentName();
            theme.sprite = ThemeSelector.Instance.GetCurrentTheme();
            price.text = ThemeSelector.Instance.GetCurrentPrice().ToString();
        }
    }
}
